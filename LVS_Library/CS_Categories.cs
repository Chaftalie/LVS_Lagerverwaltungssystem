using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public class Category
    {
        private int id;
        private string name;
        private string descpription;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Descritpion"></param>
        public Category(string _name, string _descritpion)
        {
            Name = _name;
            Description = _descritpion;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return descpription;
            }
            set
            {
                descpription = value;
            }
        }

        public static void Save(Category category)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO categories " +
                "(category_name, category_description)" +
                "VALUES " +
                "('{0}', '{1}')",
                category.Name, category.Description));
        }

        public static void Remove(Category category)
        {
            SQL_methods.SQL_exec(string.Format(
                "DELETE FROM categories " +
                "WHERE id = '{0}'",
                category.ID));
        }

        public static List<Category> All_Categories( )
        {
            string sql = "SELECT category_name as name, category_description as description FROM categories";

            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlReader.Read())
            {
                categories.Add(new Category(( string ) sqlReader["name"], ( string ) sqlReader["description"]));
            }

            return categories;
        }

    }
}
