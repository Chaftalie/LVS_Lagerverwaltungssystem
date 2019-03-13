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

        static void Started_Load()
        {
            
            Application.Run(new Form_Load());
        }

        static void Started_Main()
        {

            Application.Run(new Form_Main());
        }
    }
}
