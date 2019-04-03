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
        private string artikelnummer;
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

        public string Artikelnummer
        {
            get { return artikelnummer; }
            set { artikelnummer = value; }
        }

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

        public Item(string _name, string _description, float _width, float _length, float _height, Unit _unit, Category _category, List<Property> _properties, string _image, string _artikelnummer)
        {
            Name = _name;
            Description = _description;
            Width = _width;
            Length = _length;
            Height = _height;

            Artikelnummer = _artikelnummer;
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
            string sql = "SELECT active FROM storage_elements WHERE id = " + item.ID;
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            return ( bool ) cmd.ExecuteScalar();
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
            return ( int ) sqlReader[0];
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
                //"AND element_image = '{7}' " +
                "AND element_dataID = '{8}'", item.Name, item.Description, item.Unit.ID, item.Category.ID, item.Length, item.Width, item.Height, /*item.Image,*/ item.Artikelnummer);
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();
            return ( ( string ) sqlReader[0] == "1" );
        }

        public static bool Is_Allocated(Item item)
        {
            return Convert.ToBoolean(In_how_many_storage_spaces_is_this_item_located(item));
        }

        public static int In_how_many_storage_spaces_is_this_item_located(Item item)
        {
            if (Exists_in_DB(item))
            {
                int id = Get_DB_ID(item);
                string sql = "SELECT Count(*) FROM element_location WHERE element_location.element_id = " + item.ID;
                OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
                SQL_methods.Open();
                return ( int ) cmd.ExecuteScalar();
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns List of IDs or if not exists null</returns>
        public static List<int> Where_is(Item item)
        {
            int id = Get_DB_ID(item);
            string sql = "SELECT * FROM element_location WHERE element_location.element_id = " + item.ID;
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();
            List<int> ids = new List<int>();
            while (sqlReader.Read())
            {
                ids.Add(( int ) sqlReader[0]);
            }
            return ids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="unit">-1 ignores this parameter</param>
        /// <param name="categorie">-1 ignores this parameter</param>
        /// <param name="l0">l0 - l1 range</param>
        /// <param name="w0">w0 - w1 range</param>
        /// <param name="h0">h0 - h1 range</param>
        /// <param name="l1">l0 - l1 range</param>
        /// <param name="w1">w0 - w1 range</param>
        /// <param name="h1">h0 - h1 range</param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static List<Item> Search(string name, string description, int unit, int category, int l0, int w0, int h0, int l1, int w1, int h1, string image)
        {
            List<Unit> units = Unit.All_Units();
            List<Category> categories = Category.All_Categories();
            List<Property> properties = Property.All_Properties();
            List<NtoN> sNtopN = Property.All_sn_to_pn();

            string sql = string.Format(
                                "SELECT * FROM storage_elements WHERE " +
                                "(element_name LIKE '{0}' OR " +
                                "element_description LIKE '{1}' OR " +
                                "(element_unit_id BETWEEN {2} AND {3}) OR " +
                                "(element_category_id BETWEEN {4} AND {5}) OR " +
                                "(element_size_l BETWEEN {6} AND {7}) OR" +
                                "(element_size_w BETWEEN {8} AND {9}) OR " +
                                "(element_size_h BETWEEN {10} AND {11}) OR " +
                                "element_image LIKE '{12}') AND " +
                                "active = {13}",
                                Searching_Format(name),
                                Searching_Format(description),
                                unit, unit,
                                category, category,
                                l0, l1,
                                w0, w1,
                                h0, h1,
                                Searching_Format(image)
                                );
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();

            List<Item> items = new List<Item>();
            while (sqlReader.Read())
            {
                List<NtoN> sNtopN_ = ( from x in sNtopN where x.storage == ( int ) sqlReader["id"] select x ).ToList();
                List<Property> properties_ = ( from x in properties where sNtopN_.Any(y => x.ID == y.property) select x ).ToList();//I hope this functions correctly. I think it is alright.

                Unit unit_ = ( from x in units where x.ID == ( int ) sqlReader["element_unit_id"] select x ).First();
                //Unit unit_ = (Unit) units.Where(x => x.ID == ( int ) sqlReader["element_unit_id"]);
                Category category_ = ( from x in categories where x.ID == ( int ) sqlReader["element_category_id"] select x ).First();


                items.Add(new Item(
                    ( string ) sqlReader["element_name"],
                    ( string ) sqlReader["element_description"],
                    ( float ) sqlReader["element_size_l"],
                    ( float ) sqlReader["element_size_w"],
                    ( float ) sqlReader["element_size_h"],
                    unit_,
                    category_,
                    properties_,
                    ( string ) sqlReader["element_image"],
                    ( string ) sqlReader["id"]
                    ));
            }

            return items;

        }

        public static List<Item> All_items( )
        {
            return Search("","",-1,-1,0,0,0, int.MaxValue, int.MaxValue, int.MaxValue,"");
        }

        private static string Searching_Format(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("%");
            foreach (char c in name)
            {
                sb.Append(c);
                sb.Append("%");
            }
            sb.Append("%");

            return sb.ToString();
        }
    }
}