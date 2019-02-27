using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
