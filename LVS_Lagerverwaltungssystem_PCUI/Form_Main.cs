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
using LVS_Library;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 500;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Load_lbx_elements_all_cat();
            Load_lbx_cat_all();
        }

        #region items / elements

        private void Load_lbx_elements_all_cat( )
        {
            lbx_elements_all_cat.Items.AddRange(Category.All_Categories().ToArray());
        }

        private void btn_elements_cat_add_Click(object sender, EventArgs e)
        {
            if (!lbx_elements_used_cat.Items.Contains(lbx_elements_all_cat.SelectedItem))
            {
                lbx_elements_used_cat.Items.Add(lbx_elements_all_cat.SelectedItem);
            }
        }



        private void btn_elements_cat_del_Click(object sender, EventArgs e)
        {
            lbx_elements_used_cat.Items.Remove(lbx_elements_used_cat.SelectedItem);
        }

        private void Load_lbx_cat_all()
        {
            lbx_cat_all.Items.AddRange(Category.All_Categories().ToArray());
        }

        #endregion


        private void btn_main_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel_main_title_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel_main_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel_main_title_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_elements.Visible = true;
        }

        private void Disable_all_Panels()
        {
            panel_elements.Visible = false;
            panel_categories.Visible = false;
            panel_storage.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_categories.Left = 205;
            panel_categories.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_storage.Top = 64;
            panel_storage.Visible = true;
        }

        private void panel_categories_Paint(object sender, PaintEventArgs e)
        {
              
        }
    }
}
