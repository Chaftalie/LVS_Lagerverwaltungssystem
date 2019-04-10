using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LVS_Library
{
    public class Storage
    {
        private float width;
        private float length;
        private float height;
        private string name;
        private string description;
        private float element_count; //Stückzahl, länge der items
        private int max_count;
        private Unit unit;
        private Storage parent;
        private int id;
        private string storage_dataID;

        public float Width { get => width; set => width = value; }
        public float Length { get => length; set => length = value; }
        public float Height { get => height; set => height = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float Element_count { get => element_count; set => element_count = value; }
        public Unit Unit { get => unit; set => unit = value; }
        public Storage Parent { get => parent; set => parent = value; }
        public int ID { get => id; set => id = value; }
        public string Storage_dataID { get => storage_dataID; set => storage_dataID = value; }
        public int Max_count { get => max_count; set => max_count = value; }

        public Storage(float width, float length, float height, string name, string description, Unit unit, Storage parent, string storage_dataID, int max_count)
        {
            Width = width;
            Length = length;
            Height = height;
            Name = name;
            Description = description;
            Unit = unit;
            Parent = parent;
            Storage_dataID = storage_dataID;
            Max_count = max_count;
        }

        #region Item / Element Move store and things like that
        public void Store(Item item, float count)
        {
            if (Item.Exists_in_DB(item))
            {

                SQL_methods.SQL_exec("UPDATE storage_location SET storage_element_count = (storage_element_count + " + count + ") WHERE id = " + ID);
            }
            else
            {
                SQL_methods.SQL_exec("INSERT INTO element_location (element_id, storage_id) VALUES ("+item.ID+", "+ID);
                SQL_methods.SQL_exec("UPDATE storage_elements SET storage_element_count = " + count + "WHERE id = " + ID);
            }
                //SQL_methods.SQL_exec(String.Format("INSERT INTO storage_location (storage_location.parent_id,storage_location.storage_name,storage_location.storage_description,storage_location.storage_size_l,storage_location.storage_size_w,storage_location.storage_size_h,storage_location.storage_unit_id,storage_location.storage_element_count)" +
                 //   "VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", Parent.Id,Name,Description,Length,Width,Height,Unit.ID,))
        }

        public void Remove(Item item, float count)
        {

            SQL_methods.SQL_exec("UPDATE storage_location SET storage_element_count = (storage_element_count - " + count + ") WHERE id = " + ID);


        }
        /// <summary>
        /// IS BAD DO NOT USE UNLESS IT REALLY NEEDED!!
        /// </summary>
        public void Truncate( )
        {
            SQL_methods.SQL_exec("TRUNCATE TABLE storage_location");
        }

        static public void Move(Storage from, Storage to, Item item, float count)
        {
            using (IDbTransaction tran = DB.Connection.BeginTransaction())
            {
                try
                {
                    from.Remove(item, count);
                    to.Store(item, count);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        #endregion

        public static void Save(Storage storage)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO storage_location " +
                "(parent_id,storage_name,storage_description,storage_size_l,storage_size_w,storage_size_h,storage_unit_id,storage_max_elements,storage_dataID) " +
                "VALUES " +
                "({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, {7}, '{8}')",
                storage.Parent.ID,storage.Name,storage.Description,storage.Length,storage.Width,storage.Height,storage.Unit.ID,storage.Max_count,storage.Storage_dataID));
        }

        public static bool Is_active(Storage storage)
        {
            string sql = "SELECT storage_active FROM storage_location WHERE id = " + storage.ID;
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            return (bool)cmd.ExecuteScalar();
        }

        public static void Deactivate(Storage storage)
        {
            SQL_methods.SQL_exec("UPDATE storage_location SET storage_active = false WHERE id =" + storage.ID);
        }

        public static bool Exists_in_DB(Storage storage)
        {
            string sql = string.Format("" +
                "SELECT COUNT(*) " +
                "FROM storage_location WHERE " +
                "element_name = '{0}' " +
                "AND element_description = '{1}' " +
                "AND element_unit_id = '{2}' " +
                "AND element_size_l = '{3}' " +
                "AND element_size_w = '{4}' " +
                "AND element_size_h = '{5}' " +
                "AND element_dataID = '{6}'", storage.Name, storage.Description, storage.Unit.ID, storage.Length, storage.Width, storage.Height, storage.Storage_dataID);
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();
            sqlReader.Read();
            return (long)sqlReader[0] != 0;
        }

        public static int Get_DB_ID(Storage storage)
        {
            throw new NotImplementedException();
            /*
            string sql = string.Format("" +
                "SELECT ID " +
                "FROM storage_elements WHERE " +
                "element_name = '{0}' " +
                "AND element_description = '{1}' " +
                "AND element_unit_id = '{2}' " +
                "AND element_category_id = '{3}' " +
                "AND element_size_l = '{4}' " +
                "AND element_size_w = '{5}' " +
                "AND element_size_h = '{6}' " +
                "AND element_image = '{7}'",
                item.Name, item.Description, item.Unit.ID, item.Category.ID, item.Length, item.Width, item.Height, item.Image);

            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();
            return (int)sqlReader[0];*/
        }

    }
}
