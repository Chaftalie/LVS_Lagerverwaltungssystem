using System;
using System.Collections.Generic;
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

        public Item(string _name, string _description, float _width, float _length, float _height, Unit _unit, Category _category,List<Property> _properties, string _image, int _id)
        {
            Name = _name;
            Description = _description;
            Width = _width;
            Length = _length;
            Height = _height;

            id = _id;
            Image = _image;

            Unit = _unit;
            Category = _category;
            Properties = _properties;
        }

        public static void Save()
        {
           //SQL_methods.SQL_exec(string.Format)
        }
    }
}