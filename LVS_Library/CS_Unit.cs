using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public class Unit
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

        public float SI_Unit
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

        /// <summary>
        /// Error by Weidlböck der Seidlcöck
        /// </summary>
        /// <param name="unit"></param>
        public static void Save(Unit unit)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO properties " +
                "(unit_si, unit_name, unit_description)" +
                "VALUES " +
                "('{0}', '{1}', '{2}')",
                unit.SI_Unit, unit.Name, unit.Description));
        }
    }
}
