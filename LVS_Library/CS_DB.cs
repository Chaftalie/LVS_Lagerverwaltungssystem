using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public static class DB
    {
        private static OdbcConnection connection = null;

        public static OdbcConnection Connection
        {
            get
            {
                if (!String.IsNullOrEmpty(Database_Name) && !String.IsNullOrEmpty(Database_IP) && !String.IsNullOrEmpty(Database_Port) && !String.IsNullOrEmpty(Database_Login_Name))
                {
                    return connection ?? ( connection = new OdbcConnection(Connectionstring) );
                }
                else
                {
                    throw new NoNullAllowedException("Database login Data is not complete");
                }
            }
        }

        private static string Database_Name;
        private static string Database_IP;
        private static string Database_Port;
        private static string Database_Login_Name;
        private static string Database_Login_Password;

        public static void Give_login_Data_pls_thx( string name,string ip,string port, string login_name,string login_password)
        {
            Database_Name = name;
            Database_IP = ip;
            Database_Port = port;
            Database_Login_Name = login_name;
            Database_Login_Password = login_password;
        }

        private static string Connectionstring => $"Driver={"MySQL ODBC 5.3 Unicode Driver"};Server={Database_IP};Port={Database_Port};Database={Database_Name};User={Database_Login_Name};Password={Database_Login_Password};Option=3;";
    }

    public static class SQL_methods
    {

        static private OdbcConnection Connection => DB.Connection;

        /// <summary>
        /// Füllt DataTables mit der gewünschten SQL-Query
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        static public DataTable Fill_Box(string sql)
        {

            var da = new OdbcDataAdapter(sql, Connection);
            var dt_out = new DataTable();
            da.Fill(dt_out);

            return dt_out;
        }

        /// <summary>
        /// Führt den SQL-Befehl aus. Es wird kein Con.Open benötigt!
        /// </summary>
        /// <param name="sql"></param>
        static public void SQL_exec(string sql)
        {
            Open();
            var cmd = new OdbcCommand(sql, Connection);
            cmd.ExecuteNonQuery();


        }


        /// <summary>
        /// Benützen um Connection zu öffnen
        /// Wenn NUR diese Methode zum öffnen benützt wird braucht man KEIN Close mehr!
        /// </summary>
        static public void Open( )
        {
            Connection.Close(); //TODO add Exception thingy
            //TODO Connection.State
            Connection.Open();
        }
    }
}
