using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public class Property
    {
        private int id;
        private string name;
        private string description;

        public Property(string _name, string _description)
        {
            Name = _name;
            Description = _description;
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
                return description;
            }
            set
            {
                description = value;
            }
        }

        public int ID { get => id; set => id = value; }

        public static void Save(Property property)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO properties " +
                "(property_name, property_description)" +
                "VALUES " +
                "('{0}', '{1}')",
                property.Name, property.Description));
        }

        public static void Remove(Property property)
        {
            SQL_methods.SQL_exec(string.Format(
                "DELETE FROM properties " +
                "WHERE id = '{0}'",
                property.ID));
        }

        public static List<Property> All_Units( )
        {
            string sql = "SELECT property_name as name, property_description as description FROM properties";

            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();

            List<Property> properties = new List<Property>();

            while (sqlReader.Read())
            {
                properties.Add(new Property( ( string ) sqlReader["name"], ( string ) sqlReader["description"]));
            }

            return properties;
        }
    }
}
