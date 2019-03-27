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
            lbx_elements_all_prop.Items.AddRange(Category.All_Categories().ToArray());
        }

        private void btn_elements_cat_add_Click(object sender, EventArgs e)
        {
            if (!lbx_elements_used_prop.Items.Contains(lbx_elements_all_prop.SelectedItem))
            {
                lbx_elements_used_prop.Items.Add(lbx_elements_all_prop.SelectedItem);
            }
        }



        private void btn_elements_cat_del_Click(object sender, EventArgs e)
        {
            lbx_elements_used_prop.Items.Remove(lbx_elements_used_prop.SelectedItem);
        }

        private void Load_lbx_cat_all()
        {
            lbx_cat_all.Items.AddRange(Category.All_Categories().ToArray());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            float.TryParse(txt_elements_width.Text, out float w);
            float.TryParse(txt_elements_length.Text, out float l);
            float.TryParse(txt_elements_height.Text, out float h);
            Item.Save(new Item(txt_element_name.Text,rtx_elements_desc.Text,w,l,h,null,null,null,"nix bild hier sorry","artikelnummer"));
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
            panel_items.Visible = true;
        }

        private void Disable_all_Panels()
        {
            panel_items.Visible = false;
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

        Color hover_color = Color.FromArgb(106, 122, 137);

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            btn_dash_icon.BackColor = hover_color;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_dash_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_dash_icon_MouseEnter(object sender, EventArgs e)
        {
            btn_dash.BackColor = hover_color;
        }

        private void btn_dash_icon_MouseLeave(object sender, EventArgs e)
        {
            btn_dash.BackColor = Color.LightSlateGray;
        }

        private void btn_storage_MouseEnter(object sender, EventArgs e)
        {
            btn_storage_icon.BackColor = hover_color;
        }

        private void btn_storage_MouseLeave(object sender, EventArgs e)
        {
            btn_storage_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_storage_icon_MouseEnter(object sender, EventArgs e)
        {
            btn_storage.BackColor = hover_color;
        }

        private void btn_storage_icon_MouseLeave(object sender, EventArgs e)
        {
            btn_storage.BackColor = Color.LightSlateGray;
        }

        private void btn_prop_MouseEnter(object sender, EventArgs e)
        {
            btn_prop_icon.BackColor = hover_color;
        }

        private void btn_prop_MouseLeave(object sender, EventArgs e)
        {
            btn_prop_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_prop_icon_MouseEnter(object sender, EventArgs e)
        {
            btn_prop.BackColor = hover_color;
        }

        private void btn_prop_icon_MouseLeave(object sender, EventArgs e)
        {
            btn_prop.BackColor = Color.LightSlateGray;
        }
        
        private void btn_items_MouseEnter(object sender, EventArgs e)
        {
            btn_items_icon.BackColor = hover_color;
        }

        private void btn_items_MouseLeave(object sender, EventArgs e)
        {
            btn_items_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_items_icon_MouseEnter(object sender, EventArgs e)
        {
            btn_items.BackColor = hover_color;
        }

        private void btn_items_icon_MouseLeave(object sender, EventArgs e)
        {
            btn_items.BackColor = Color.LightSlateGray;
        }
        
    }
}
