using LVS_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.Give_login_Data_pls_thx(Properties.Settings.Default.Database_Name, Properties.Settings.Default.Database_IP, Properties.Settings.Default.Database_Port, Properties.Settings.Default.Database_Login_Name, Properties.Settings.Default.Database_Login_Password);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Login());
        }
        
        public static void Start_Load()
        {
            Thread t = new Thread(Started_Load);
            t.Start();
        }

        public static void Start_Main()
        {
            Thread t_main = new Thread(Started_Main);
            t_main.Start();
        }

        [STAThread]
        static void Started_Load()
        {   
            Application.Run(new Form_Load());
        }

        [STAThread]
        static void Started_Main()
        {
            Application.Run(new Form_Main());
        }
    }
}
