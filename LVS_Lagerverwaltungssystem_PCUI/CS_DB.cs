using System;
using System.Collections.Generic;
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
}
