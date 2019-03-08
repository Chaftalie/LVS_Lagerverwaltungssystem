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
    public partial class Form_Load : Form
    {
        private Timer time_load = new Timer();
        private Timer time_text = new Timer();
        public Form_Load()
        {
            InitializeComponent();

            panel_load_mover.Left = 0;
        }

        private int panel_plus = 2;

        private int text_counter = 1;

        void Load_Move(object sender, EventArgs e)
        {
            panel_load_mover.Left += panel_plus;

            if (panel_load_mover.Left > 440)
            {
                panel_plus = -2;
            }

            if (panel_load_mover.Left < 1)
            {
                panel_plus = 2;
            }


        }

        void Load_Text(object sender, EventArgs e)
        {
            switch (text_counter)
            {
                case 1:
                    lbl_load.Text = "Loading, please wait...";
                    text_counter++;
                    break;
                case 2:
                    lbl_load.Text = "Loading, please wait..";
                    text_counter++;
                    break;
                case 3:
                    lbl_load.Text = "Loading, please wait.";
                    text_counter++;
                    break;
                case 4:
                    lbl_load.Text = "Loading, please wait..";
                    text_counter = 1;
                    break;
            }
        }

        private void Form_Load_Load(object sender, EventArgs e)
        {
            time_load.Tick += new EventHandler(Load_Move);
            time_load.Interval = 2;
            time_load.Start();

            time_text.Tick += new EventHandler(Load_Text);
            time_text.Interval = 70;
            time_text.Start();

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
    }
}
