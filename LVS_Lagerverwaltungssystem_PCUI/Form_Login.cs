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
    public partial class Form_Login : Form
    {
        Timer time_register = new Timer();
        Label logreg = new Label();

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
            Program.Start_Load();
            this.Close();
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
    }
}
