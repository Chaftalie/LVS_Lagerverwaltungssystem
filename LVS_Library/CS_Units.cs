using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    class Unit
    {
        private int id;
        private float si_unit;
        private string description;
        private string name;

        /// <summary>
        /// Generates a new Unit for usage in a Storage or Item
        /// </summary>
        /// <param name="SI Unit"></param>
        /// <param name="Description"></param>
        /// <param name="Name"></param>
        public Unit(float _si_unit, string _description, string _name)
        {
            SI_Units = _si_unit;
            Description = _description;
            Name = _name;
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

        public float SI_Units
        {
            get
            {
                return si_unit;
            }
            set
            {
                si_unit = value;
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
    }
}
