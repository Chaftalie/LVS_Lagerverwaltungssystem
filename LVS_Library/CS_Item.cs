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
        private Property property;

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

        public Property Property
        {
            get { return property; }
            set { property = value; }
        }

        public Item(string name, string description, float width, float height, float length, string image, Unit unit, Category category, Property property)
        {
            Name = name;
            Description = description;
            Width = width;
            Height = height;
            Length = length;
            Image = image;
            Unit = unit;
            Category = category;
            Property = property;
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
            if (( string ) sqlReader[0] == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}