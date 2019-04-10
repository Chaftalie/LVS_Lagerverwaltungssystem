using System;
using LVS_Library;
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

    
    public partial class Form_Login : Form
    {
        Timer time_register = new Timer();
        Label logreg = new Label();
        static string hash_user_name;

        public Form_Login()
        {
            InitializeComponent();
            
            this.Size = new Size(550, 545);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //Form form_load = new Form_Load();
            hash_user_name = txt_login_name.Text;
            if (Convert.ToBoolean(SQL_methods.SQL_scalar("SELECT CASE WHEN EXISTS(SELECT * FROM users WHERE user = '"+txt_login_name.Text+"' AND password = '"+SHA256(txt_login_password.Text)+"') THEN CAST(1 AS int) ELSE CAST(0 AS int) END"))){
                Program.Start_Load();
                this.Close();
            }
            else
            {
                MessageBox.Show("User/Password not found!");
            }
            
        }

        private bool mouseDown;
        private Point lastLocation;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            mouseDown = false;

        }

        private void Form_Login_LoadReg(object sender, EventArgs e)
        {
            time_register.Tick += new EventHandler(timer2_go);
            time_register.Interval = 5;
            time_register.Start();
        }

        void timer2_go(object sender, EventArgs e)
        {
            if (logreg.Text == "Register")
            {
                reg();
            }
            else if (logreg.Text == "Back")
            {
                log();
            }
        }

        void Line()
        {
            if (panel_register.Left == -10)
            {
                bunifuSeparator2.Height = 2;
                bunifuSeparator2.BackColor = Color.LightGray;
                bunifuSeparator1.Height = 1;
                bunifuSeparator1.BackColor = Color.DeepSkyBlue;
            }
            if (panel_login.Left == 0)
            {
                bunifuSeparator2.Height = 1;
                bunifuSeparator2.BackColor = Color.DeepSkyBlue;
                bunifuSeparator1.Height = 2;
                bunifuSeparator1.BackColor = Color.LightGray;
            }
        }


        int move_speed = 20;
        void reg()
        {
            if (panel_register.Left > 0)
            {
                
                Line();

                panel_login.Left -= move_speed;
                panel_register.Left -= move_speed;
                if (panel_register.Left == 0)
                {
                    time_register.Stop();
                }
            }
        }
        void log()
        {
            if (panel_login.Left < 0)
            {
                Line();

                panel_register.Left += move_speed;
                panel_login.Left += move_speed;
                if (panel_login.Left == 0)
                {
                    time_register.Stop();
                }
            }
        }

        private void Register(object sender, EventArgs e)
        {

            logreg.Text = (sender as Button).Text;
            time_register.Start();
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            string hash;
            hash_user_name = txt_reg_name.Text;

            hash = SHA256(txt_reg_password.Text);

            SQL_methods.SQL_exec("INSERT INTO users (user, password) VALUES ('"+txt_reg_name.Text+"', '"+hash+"')");
            
        }

        static string SHA256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();

            randomString = "LVS" + randomString + hash_user_name;

            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));


            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
