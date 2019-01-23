using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    class DB
    {
        private static OdbcConnection connection = null;

        public static OdbcConnection Connection => connection ?? (connection = new OdbcConnection(Connectionstring));

        private static string Database_IP => "root";
        private static string Database_Port => "root";
        private static string Database_Name => "root";
        private static string Database_Login_Name => "root";
        private static string Database_Login_Password => "root";

        private static string Connectionstring => $"Driver={"MySQL ODBC 5.3 Unicode Driver"};Server={Database_IP};Port={Database_Port};Database={Database_Name};User={Database_Login_Name};Password={Database_Login_Password};Option=3;";
    }

    class SQL_methods
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
        static public void Open()
        {
            Connection.Close(); //TODO add Exception thingy
            //TODO Connection.State
            Connection.Open();
        }
    }
}
