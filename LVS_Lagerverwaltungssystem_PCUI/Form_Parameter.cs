using LVS_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LVS_Lagerverwaltungssystem_PCUI
{
    public partial class Form_Parameter : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Form_Parameter()
        {
            InitializeComponent();
            Fill_Database_tBx_thingys();
            
        }

        private void Fill_Database_tBx_thingys()
        {
            tBx_DB_Name.Text = Properties.Settings.Default.Database_Name;
            tBx_IP.Text = Properties.Settings.Default.Database_IP;
            tBx_Port.Text = Properties.Settings.Default.Database_Port;
            tBx_Login_Name.Text = Properties.Settings.Default.Database_Login_Name;
            tBx_Login_Password.Text = Properties.Settings.Default.Database_Login_Password;
        }

        private void btn_save_DB_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Database_Name = tBx_DB_Name.Text;
            Properties.Settings.Default.Database_IP = tBx_IP.Text;
            Properties.Settings.Default.Database_Port = tBx_Port.Text;
            Properties.Settings.Default.Database_Login_Name = tBx_Login_Name.Text;
            Properties.Settings.Default.Database_Login_Password = tBx_Login_Password.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_resett_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Wüst du wiakle de Datenbank Daten wiakle zrucksetzen?", "Warnung", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Database_Name = "lsv_lagerverwaltungssystem";
                Properties.Settings.Default.Database_IP = "81.10.155.134";
                Properties.Settings.Default.Database_Port = "1337";
                Properties.Settings.Default.Database_Login_Name = "root";
                Properties.Settings.Default.Database_Login_Password = "cola0815";

                Fill_Database_tBx_thingys();
            }
        }

        private void btn_check_connection_Click(object sender, EventArgs e)
        {
            DB.Give_login_Data_pls_thx(Properties.Settings.Default.Database_Name, Properties.Settings.Default.Database_IP, Properties.Settings.Default.Database_Port, Properties.Settings.Default.Database_Login_Name, Properties.Settings.Default.Database_Login_Password);
            try
            {
                SQL_methods.Open();
                MessageBox.Show("You did it\nit works\nlol", "Congrats", MessageBoxButtons.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something did not work\nSome informatione (I hope it can help):" + exception.Message, "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_par_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
