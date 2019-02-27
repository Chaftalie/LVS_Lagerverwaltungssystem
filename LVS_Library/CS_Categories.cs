using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public class Categories
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
    }
}
