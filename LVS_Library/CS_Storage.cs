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
        private Unit unit;
        private Storage parent;
        private int id;

        public float Width { get => width; set => width = value; }
        public float Length { get => length; set => length = value; }
        public float Height { get => height; set => height = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float Element_count { get => element_count; set => element_count = value; }
        public Unit Unit { get => unit; set => unit = value; }
        public Storage Parent { get => parent; set => parent = value; }
        public int Id { get => id; set => id = value; }

        public Storage(float width, float length, float height, string name, Storage parent, int id)
        {
            Width = width;
            Length = length;
            Height = height;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent;
            Id = id;
        }

        public void Store(Item item, float count)
        {
            if (Exist_in_DB(item))
            {

                SQL_methods.SQL_exec("UPDATE storage_location SET storage_element_count = (storage_element_count + " + count + ") WHERE id = " + Id);
            }
            else
            {
                SQL_methods.SQL_exec("INSERT INTO element_location (element_id, storage_id) VALUES ("+item.ID+", "+Id);
                SQL_methods.SQL_exec("UPDATE storage_elements SET storage_element_count = " + count + "WHERE id = " + Id);
            }
                //SQL_methods.SQL_exec(String.Format("INSERT INTO storage_location (storage_location.parent_id,storage_location.storage_name,storage_location.storage_description,storage_location.storage_size_l,storage_location.storage_size_w,storage_location.storage_size_h,storage_location.storage_unit_id,storage_location.storage_element_count)" +
                 //   "VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", Parent.Id,Name,Description,Length,Width,Height,Unit.ID,))
        }

        public void Remove(Item item, float count)
        {

            SQL_methods.SQL_exec("UPDATE storage_location SET storage_element_count = (storage_element_count - " + count + ") WHERE id = " + Id);


        }

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
    }
}
