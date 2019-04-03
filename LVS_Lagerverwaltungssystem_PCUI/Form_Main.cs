using LVS_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            Load_all_for_element();
            Load_lbx_cat_all();
            ( ( Control ) pBx_elements_image ).AllowDrop = true;
            pBx_elements_image.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #region items / elements

        private void Load_all_for_element()
        {
            lbx_elements_all_prop.Items.AddRange(Property.All_Properties().ToArray());
            cbx_elements_cat.Items.AddRange(Category.All_Categories().ToArray());
            cbx_elements_unit.Items.AddRange(Unit.All_Units().ToArray());
        }

        private void btn_elements_cat_add_Click(object sender, EventArgs e)
        {
            if (lbx_elements_all_prop.SelectedItem != null)
            {
                if (!lbx_elements_used_prop.Items.Contains(lbx_elements_all_prop.SelectedItem))
                {
                    lbx_elements_used_prop.Items.Add(lbx_elements_all_prop.SelectedItem);
                }
            }
        }

        private void btn_elements_cat_del_Click(object sender, EventArgs e)
        {
            if (lbx_elements_used_prop.SelectedItem != null)
            {
                lbx_elements_used_prop.Items.Remove(lbx_elements_used_prop.SelectedItem);
            }
        }

        private void Load_lbx_cat_all()
        {
            lbx_cat_all.Items.AddRange(Category.All_Categories().ToArray());
        }

        //TODO add method to check if element is already 
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!Elements_misses_parts_get_num(out float w, out float l, out float h))
            {
                List<Property> properties = new List<Property>();
                foreach (Property property in lbx_elements_used_prop.Items)
                {
                    properties.Add(property);
                }

                Category category = (Category)cbx_elements_cat.SelectedItem;

                Unit unit = (Unit)cbx_elements_unit.SelectedItem;

                string imagebase64 = "";
                if (pBx_elements_image.Image != null)
                {
                    imagebase64 = ImageStuff.GetStringFromImage(pBx_elements_image.Image);
                }

                Item.Save(new Item(txt_element_name.Text, rtx_elements_desc.Text, w, l, h, unit, category, properties, imagebase64, txt_articel_number.Text));
            }
            else
            {
                MessageBox.Show("Bitte alle Felder ausfüllen\n we know taht we have to add something more here");
            }
        }

        private bool Elements_misses_parts_get_num(out float w, out float l, out float h)
        {
            List<bool> missing_parts_list = new List<bool>();
            missing_parts_list.Add(float.TryParse(txt_elements_width.Text, out w));
            missing_parts_list.Add(float.TryParse(txt_elements_length.Text, out l));
            missing_parts_list.Add(float.TryParse(txt_elements_height.Text, out h));
            missing_parts_list.Add(txt_element_name.Text != "");
            missing_parts_list.Add(rtx_elements_desc.Text != "");
            missing_parts_list.Add(cbx_elements_unit.Text != "");
            missing_parts_list.Add(cbx_elements_cat.Text != "");
            missing_parts_list.Add(lbx_elements_used_prop.Items.Count > 0);

            foreach (var _ in from bool result in missing_parts_list
                              where !result
                              select new { })
            {
                return true;
            }
            return false;
        }

        private void btn_image_upload_Click(object sender, EventArgs e)
        {
            if (oFD_element_Image.ShowDialog() == DialogResult.OK)
            {
                pBx_elements_image.Image = Image.FromFile(oFD_element_Image.FileName);
            }
        }

        private void openfiledialogtest()
        {
            if (oFD_element_Image.ShowDialog() == DialogResult.OK)
            {
                pBx_elements_image.Image = Image.FromFile(oFD_element_Image.FileName);
            }
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

        private void btn_items_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_items.Visible = true;

        }

        private void Disable_all_Panels()
        {
            panel_items.Visible = false;
            panel_categories.Visible = false;
            panel_storage.Visible = false;
            panel_user.Visible = false;
            panel_properties.Visible = false;
            panel_dashboard.Visible = false;
        }

        private void btn_cat_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_categories.Left = 205;
            panel_categories.Visible = true;
        }

        private void btn_storage_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_storage.Top = 64;
            panel_storage.Left = 205;
            panel_storage.Visible = true;
        }

        Color hover_color = Color.FromArgb(106, 122, 137);
        Color click_color = Color.FromArgb(171, 175, 182);

        private void btn_dash_MouseEnter(object sender, EventArgs e)
        {

            btn_dash_icon.BackColor = hover_color;
        }

        private void btn_dash_MouseLeave(object sender, EventArgs e)
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


        private void btn_items_MouseEnter_1(object sender, EventArgs e)
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

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            btn_icon_cat.BackColor = hover_color;
        }

        private void btn_cat_MouseLeave(object sender, EventArgs e)
        {
            btn_icon_cat.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_cat_MouseEnter(object sender, EventArgs e)
        {
            btn_cat.BackColor = hover_color;
        }

        private void btn_icon_cat_MouseLeave(object sender, EventArgs e)
        {
            btn_cat.BackColor = Color.LightSlateGray;
        }

        private void btn_user_MouseHover(object sender, EventArgs e)
        {

        }

        private void btn_user_MouseEnter(object sender, EventArgs e)
        {
            btn_icon_user.BackColor = hover_color;
        }

        private void btn_user_MouseLeave(object sender, EventArgs e)
        {
            btn_icon_user.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_user_MouseEnter(object sender, EventArgs e)
        {
            btn_user.BackColor = hover_color;
        }

        private void btn_icon_user_MouseLeave(object sender, EventArgs e)
        {
            btn_user.BackColor = Color.LightSlateGray;
        }

        private void btn_settings_MouseEnter(object sender, EventArgs e)
        {
            btn_icon_setting.BackColor = hover_color;
        }

        private void btn_settings_MouseLeave(object sender, EventArgs e)
        {
            btn_icon_setting.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_setting_MouseEnter(object sender, EventArgs e)
        {
            btn_settings.BackColor = hover_color;
        }

        private void btn_icon_setting_MouseLeave(object sender, EventArgs e)
        {
            btn_settings.BackColor = Color.LightSlateGray;
        }

        private void btn_dash_MouseDown(object sender, MouseEventArgs e)
        {
            btn_dash_icon.BackColor = click_color;
        }

        private void btn_dash_MouseUp(object sender, MouseEventArgs e)
        {
            btn_dash_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_dash_icon_MouseDown(object sender, MouseEventArgs e)
        {
            btn_dash.BackColor = click_color;
        }

        private void btn_dash_icon_MouseUp(object sender, MouseEventArgs e)
        {
            btn_dash.BackColor = Color.LightSlateGray;
        }

        private void btn_storage_MouseDown(object sender, MouseEventArgs e)
        {
            btn_storage_icon.BackColor = click_color;
        }

        private void btn_storage_MouseUp(object sender, MouseEventArgs e)
        {
            btn_storage_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_storage_icon_MouseDown(object sender, MouseEventArgs e)
        {
            btn_storage.BackColor = click_color;
        }

        private void btn_storage_icon_MouseUp(object sender, MouseEventArgs e)
        {
            btn_storage.BackColor = Color.LightSlateGray;
        }

        private void btn_prop_MouseDown(object sender, MouseEventArgs e)
        {
            btn_prop_icon.BackColor = click_color;
        }

        private void btn_prop_MouseUp(object sender, MouseEventArgs e)
        {
            btn_prop_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_prop_icon_MouseDown(object sender, MouseEventArgs e)
        {
            btn_prop.BackColor = click_color;
        }

        private void btn_prop_icon_MouseUp(object sender, MouseEventArgs e)
        {
            btn_prop.BackColor = Color.LightSlateGray;
        }

        private void btn_items_MouseDown(object sender, MouseEventArgs e)
        {
            btn_items_icon.BackColor = click_color;
        }

        private void btn_items_MouseUp(object sender, MouseEventArgs e)
        {
            btn_items_icon.BackColor = Color.LightSlateGray;
        }

        private void btn_items_icon_MouseDown(object sender, MouseEventArgs e)
        {
            btn_items.BackColor = click_color;
        }

        private void btn_items_icon_MouseUp(object sender, MouseEventArgs e)
        {
            btn_items.BackColor = Color.LightSlateGray;
        }

        private void btn_cat_MouseDown(object sender, MouseEventArgs e)
        {
            btn_icon_cat.BackColor = click_color;
        }

        private void btn_cat_MouseUp(object sender, MouseEventArgs e)
        {
            btn_icon_cat.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_cat_MouseDown(object sender, MouseEventArgs e)
        {
            btn_cat.BackColor = click_color;
        }

        private void btn_icon_cat_MouseUp(object sender, MouseEventArgs e)
        {
            btn_cat.BackColor = Color.LightSlateGray;
        }

        private void btn_user_MouseDown(object sender, MouseEventArgs e)
        {
            btn_icon_user.BackColor = click_color;
        }

        private void btn_user_MouseUp(object sender, MouseEventArgs e)
        {
            btn_icon_user.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_user_MouseDown(object sender, MouseEventArgs e)
        {
            btn_user.BackColor = click_color;
        }

        private void btn_icon_user_MouseUp(object sender, MouseEventArgs e)
        {
            btn_user.BackColor = Color.LightSlateGray;
        }

        private void btn_settings_MouseDown(object sender, MouseEventArgs e)
        {
            btn_icon_setting.BackColor = click_color;
        }

        private void btn_settings_MouseUp(object sender, MouseEventArgs e)
        {
            btn_icon_setting.BackColor = Color.LightSlateGray;
        }

        private void btn_icon_setting_MouseDown(object sender, MouseEventArgs e)
        {
            btn_settings.BackColor = click_color;
        }

        private void btn_icon_setting_MouseUp(object sender, MouseEventArgs e)
        {
            btn_settings.BackColor = Color.LightSlateGray;
        }

        private void pBx_elements_image_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pBx_elements_image_DragDrop(object sender, DragEventArgs e)
        {
            pBx_elements_image.Image = Image.FromFile(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_user.Left = 205;
            panel_user.Top = 64;
            panel_user.Visible = true;
        }

        private void btn_prop_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_properties.Left = 205;
            panel_properties.Top = 64;
            panel_properties.Visible = true;
        }

        private void btn_dash_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_dashboard.Left = 205;
            panel_dashboard.Top = 64;
            panel_dashboard.Visible = true;
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Form form_set = new Form_Parameter();
            form_set.Show();
        }
    }
}
