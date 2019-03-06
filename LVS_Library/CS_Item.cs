using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LVS_Library
{
    public class Item
    {

        private int id;
        private string name;
        private string description;
        private float width;
        private float length;
        private float height;

        // TODO
        private string image;
        private Unit unit;
        private Category category;
        private List<Property> properties;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        // TODO
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public List<Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public Item(string _name, string _description, float _width, float _length, float _height, Unit _unit, Category _category, List<Property> _properties, string _image, int _id)
        { 
            Name = _name;
            Description = _description;
            Width = _width;
            Length = _length;
            Height = _height;

            ID = _id;
            Image = _image;

            Unit = _unit;
            Category = _category;
            Properties = _properties;
        }

        public static void Save(Item item)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO storage_elements " +
                "(element_name, element_description, element_unit_id, element_category_id, element_size_l, element_size_w, element_size_h, element_image) " +
                "VALUES " +
                "('{0}', '{1}', {2}, {3}, {4}, {5}, {6}, '{7}')",
                item.Name, item.Description, item.Unit.ID, item.Category.ID, item.Length, item.Width, item.Height, item.Image));
        }
         
        public static bool Is_active(Item item)
        {
            string sql = "SELECT active FROM storage_elements WHERE id = " + item.ID ;
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            return (bool)cmd.ExecuteScalar();
        }

        public static void Deactivate(Item item)
        {
            SQL_methods.SQL_exec("UPDATE storage_elements SET active = false WHERE id = " + item.ID);
        }

        public static int Get_DB_ID(Item item)
        {
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
            return (int)sqlReader[0];
        }

        public static bool Exists_in_DB(Item item)
        {
            string sql = string.Format("" +
                "SELECT COUNT(*) " +
                "FROM storage_elements WHERE " +
                "element_name = '{0}' " +
                "AND element_description = '{1}' " +
                "AND element_unit_id = '{2}' " +
                "AND element_category_id = '{3}' " +
                "AND element_size_l = '{4}' " +
                "AND element_size_w = '{5}' " +
                "AND element_size_h = '{6}' " +
                "AND element_image = '{7}'", item.Name, item.Description, item.Unit.ID, item.Category.ID, item.Length, item.Width, item.Height, item.Image);
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();
            return ((string)sqlReader[0] == "1");

        }
    }
}