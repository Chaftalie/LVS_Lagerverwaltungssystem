namespace LVS_Lagerverwaltungssystem_PCUI
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main_title = new System.Windows.Forms.Panel();
            this.btn_main_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_elements = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_elements = new System.Windows.Forms.Panel();
            this.btn_elements_cat_del = new System.Windows.Forms.Button();
            this.btn_elements_cat_add = new System.Windows.Forms.Button();
            this.lbl_length = new System.Windows.Forms.Label();
            this.txt_elements_length = new System.Windows.Forms.TextBox();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.lbl_category = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_elements_width = new System.Windows.Forms.TextBox();
            this.txt_elements_height = new System.Windows.Forms.TextBox();
            this.lbx_elements_used_cat = new System.Windows.Forms.ListBox();
            this.lbx_elements_all_cat = new System.Windows.Forms.ListBox();
            this.rtx_elements_desc = new System.Windows.Forms.RichTextBox();
            this.txt_element_name = new System.Windows.Forms.TextBox();
            this.panel_categories = new System.Windows.Forms.Panel();
            this.lbl_cat_name = new System.Windows.Forms.Label();
            this.txt_cat_name = new System.Windows.Forms.TextBox();
            this.btn_cat_delete = new System.Windows.Forms.Button();
            this.btn_cat_add = new System.Windows.Forms.Button();
            this.lbx_cat_all = new System.Windows.Forms.ListBox();
            this.panel_storage = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel_main_title.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_elements.SuspendLayout();
            this.panel_categories.SuspendLayout();
            this.panel_storage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main_title
            // 
            this.panel_main_title.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel_main_title.Controls.Add(this.btn_main_close);
            this.panel_main_title.Location = new System.Drawing.Point(0, 0);
            this.panel_main_title.Name = "panel_main_title";
            this.panel_main_title.Size = new System.Drawing.Size(1000, 23);
            this.panel_main_title.TabIndex = 0;
            this.panel_main_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_main_title_MouseDown);
            this.panel_main_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_main_title_MouseMove);
            this.panel_main_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_main_title_MouseUp);
            // 
            // btn_main_close
            // 
            this.btn_main_close.FlatAppearance.BorderSize = 0;
            this.btn_main_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_main_close.Location = new System.Drawing.Point(968, 0);
            this.btn_main_close.Name = "btn_main_close";
            this.btn_main_close.Size = new System.Drawing.Size(32, 23);
            this.btn_main_close.TabIndex = 0;
            this.btn_main_close.Text = "X";
            this.btn_main_close.UseVisualStyleBackColor = true;
            this.btn_main_close.Click += new System.EventHandler(this.btn_main_close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btn_elements);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 479);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(64, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "| Systems";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "LVS";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightSlateGray;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(90, 432);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(74, 33);
            this.button7.TabIndex = 6;
            this.button7.Text = "Settings";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightSlateGray;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 432);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 33);
            this.button6.TabIndex = 5;
            this.button6.Text = "User";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSlateGray;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 33);
            this.button5.TabIndex = 4;
            this.button5.Text = "Categories";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_elements
            // 
            this.btn_elements.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_elements.FlatAppearance.BorderSize = 0;
            this.btn_elements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_elements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_elements.ForeColor = System.Drawing.Color.White;
            this.btn_elements.Location = new System.Drawing.Point(12, 276);
            this.btn_elements.Name = "btn_elements";
            this.btn_elements.Size = new System.Drawing.Size(152, 33);
            this.btn_elements.TabIndex = 3;
            this.btn_elements.Text = "Elements";
            this.btn_elements.UseVisualStyleBackColor = false;
            this.btn_elements.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSlateGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 33);
            this.button3.TabIndex = 2;
            this.button3.Text = "Items";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSlateGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Storage";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSlateGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "DashBoard";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel_elements
            // 
            this.panel_elements.BackColor = System.Drawing.Color.Transparent;
            this.panel_elements.Controls.Add(this.btn_elements_cat_del);
            this.panel_elements.Controls.Add(this.btn_elements_cat_add);
            this.panel_elements.Controls.Add(this.lbl_length);
            this.panel_elements.Controls.Add(this.txt_elements_length);
            this.panel_elements.Controls.Add(this.lbl_height);
            this.panel_elements.Controls.Add(this.lbl_width);
            this.panel_elements.Controls.Add(this.lbl_category);
            this.panel_elements.Controls.Add(this.lbl_desc);
            this.panel_elements.Controls.Add(this.lbl_name);
            this.panel_elements.Controls.Add(this.txt_elements_width);
            this.panel_elements.Controls.Add(this.txt_elements_height);
            this.panel_elements.Controls.Add(this.lbx_elements_used_cat);
            this.panel_elements.Controls.Add(this.lbx_elements_all_cat);
            this.panel_elements.Controls.Add(this.rtx_elements_desc);
            this.panel_elements.Controls.Add(this.txt_element_name);
            this.panel_elements.Location = new System.Drawing.Point(205, 64);
            this.panel_elements.Name = "panel_elements";
            this.panel_elements.Size = new System.Drawing.Size(433, 424);
            this.panel_elements.TabIndex = 2;
            this.panel_elements.Visible = false;
            // 
            // btn_elements_cat_del
            // 
            this.btn_elements_cat_del.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_elements_cat_del.FlatAppearance.BorderSize = 0;
            this.btn_elements_cat_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_elements_cat_del.Location = new System.Drawing.Point(8, 222);
            this.btn_elements_cat_del.Name = "btn_elements_cat_del";
            this.btn_elements_cat_del.Size = new System.Drawing.Size(75, 23);
            this.btn_elements_cat_del.TabIndex = 29;
            this.btn_elements_cat_del.Text = "Delete";
            this.btn_elements_cat_del.UseVisualStyleBackColor = false;
            // 
            // btn_elements_cat_add
            // 
            this.btn_elements_cat_add.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_elements_cat_add.FlatAppearance.BorderSize = 0;
            this.btn_elements_cat_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_elements_cat_add.Location = new System.Drawing.Point(8, 193);
            this.btn_elements_cat_add.Name = "btn_elements_cat_add";
            this.btn_elements_cat_add.Size = new System.Drawing.Size(75, 23);
            this.btn_elements_cat_add.TabIndex = 28;
            this.btn_elements_cat_add.Text = "Add";
            this.btn_elements_cat_add.UseVisualStyleBackColor = false;
            // 
            // lbl_length
            // 
            this.lbl_length.AutoSize = true;
            this.lbl_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_length.ForeColor = System.Drawing.Color.White;
            this.lbl_length.Location = new System.Drawing.Point(4, 360);
            this.lbl_length.Name = "lbl_length";
            this.lbl_length.Size = new System.Drawing.Size(51, 16);
            this.lbl_length.TabIndex = 27;
            this.lbl_length.Text = "Length:";
            // 
            // txt_elements_length
            // 
            this.txt_elements_length.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_elements_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_elements_length.Location = new System.Drawing.Point(111, 360);
            this.txt_elements_length.Multiline = true;
            this.txt_elements_length.Name = "txt_elements_length";
            this.txt_elements_length.Size = new System.Drawing.Size(145, 23);
            this.txt_elements_length.TabIndex = 26;
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_height.ForeColor = System.Drawing.Color.White;
            this.lbl_height.Location = new System.Drawing.Point(5, 321);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(50, 16);
            this.lbl_height.TabIndex = 25;
            this.lbl_height.Text = "Height:";
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_width.ForeColor = System.Drawing.Color.White;
            this.lbl_width.Location = new System.Drawing.Point(5, 283);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(45, 16);
            this.lbl_width.TabIndex = 24;
            this.lbl_width.Text = "Width:";
            // 
            // lbl_category
            // 
            this.lbl_category.AutoSize = true;
            this.lbl_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_category.ForeColor = System.Drawing.Color.White;
            this.lbl_category.Location = new System.Drawing.Point(5, 161);
            this.lbl_category.Name = "lbl_category";
            this.lbl_category.Size = new System.Drawing.Size(77, 16);
            this.lbl_category.TabIndex = 23;
            this.lbl_category.Text = "Categories:";
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.ForeColor = System.Drawing.Color.White;
            this.lbl_desc.Location = new System.Drawing.Point(5, 55);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(79, 16);
            this.lbl_desc.TabIndex = 22;
            this.lbl_desc.Text = "Descirption:";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.White;
            this.lbl_name.Location = new System.Drawing.Point(5, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(100, 16);
            this.lbl_name.TabIndex = 21;
            this.lbl_name.Text = "Element Name:";
            // 
            // txt_elements_width
            // 
            this.txt_elements_width.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_elements_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_elements_width.Location = new System.Drawing.Point(111, 283);
            this.txt_elements_width.Multiline = true;
            this.txt_elements_width.Name = "txt_elements_width";
            this.txt_elements_width.Size = new System.Drawing.Size(145, 23);
            this.txt_elements_width.TabIndex = 20;
            // 
            // txt_elements_height
            // 
            this.txt_elements_height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_elements_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_elements_height.Location = new System.Drawing.Point(111, 321);
            this.txt_elements_height.Multiline = true;
            this.txt_elements_height.Name = "txt_elements_height";
            this.txt_elements_height.Size = new System.Drawing.Size(145, 23);
            this.txt_elements_height.TabIndex = 19;
            // 
            // lbx_elements_used_cat
            // 
            this.lbx_elements_used_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_elements_used_cat.FormattingEnabled = true;
            this.lbx_elements_used_cat.ItemHeight = 16;
            this.lbx_elements_used_cat.Location = new System.Drawing.Point(280, 176);
            this.lbx_elements_used_cat.Name = "lbx_elements_used_cat";
            this.lbx_elements_used_cat.Size = new System.Drawing.Size(145, 84);
            this.lbx_elements_used_cat.TabIndex = 18;
            // 
            // lbx_elements_all_cat
            // 
            this.lbx_elements_all_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_elements_all_cat.FormattingEnabled = true;
            this.lbx_elements_all_cat.ItemHeight = 16;
            this.lbx_elements_all_cat.Location = new System.Drawing.Point(111, 176);
            this.lbx_elements_all_cat.Name = "lbx_elements_all_cat";
            this.lbx_elements_all_cat.Size = new System.Drawing.Size(145, 84);
            this.lbx_elements_all_cat.TabIndex = 17;
            // 
            // rtx_elements_desc
            // 
            this.rtx_elements_desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtx_elements_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtx_elements_desc.Location = new System.Drawing.Point(111, 55);
            this.rtx_elements_desc.Name = "rtx_elements_desc";
            this.rtx_elements_desc.Size = new System.Drawing.Size(145, 96);
            this.rtx_elements_desc.TabIndex = 16;
            this.rtx_elements_desc.Text = "Desc";
            // 
            // txt_element_name
            // 
            this.txt_element_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_element_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_element_name.Location = new System.Drawing.Point(111, 13);
            this.txt_element_name.Multiline = true;
            this.txt_element_name.Name = "txt_element_name";
            this.txt_element_name.Size = new System.Drawing.Size(145, 23);
            this.txt_element_name.TabIndex = 15;
            this.txt_element_name.Text = "Name";
            // 
            // panel_categories
            // 
            this.panel_categories.BackColor = System.Drawing.Color.Transparent;
            this.panel_categories.Controls.Add(this.lbl_cat_name);
            this.panel_categories.Controls.Add(this.txt_cat_name);
            this.panel_categories.Controls.Add(this.btn_cat_delete);
            this.panel_categories.Controls.Add(this.btn_cat_add);
            this.panel_categories.Controls.Add(this.lbx_cat_all);
            this.panel_categories.Location = new System.Drawing.Point(653, 64);
            this.panel_categories.Name = "panel_categories";
            this.panel_categories.Size = new System.Drawing.Size(433, 424);
            this.panel_categories.TabIndex = 3;
            this.panel_categories.Visible = false;
            // 
            // lbl_cat_name
            // 
            this.lbl_cat_name.AutoSize = true;
            this.lbl_cat_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cat_name.ForeColor = System.Drawing.Color.White;
            this.lbl_cat_name.Location = new System.Drawing.Point(24, 124);
            this.lbl_cat_name.Name = "lbl_cat_name";
            this.lbl_cat_name.Size = new System.Drawing.Size(45, 16);
            this.lbl_cat_name.TabIndex = 5;
            this.lbl_cat_name.Text = "Name";
            // 
            // txt_cat_name
            // 
            this.txt_cat_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cat_name.Location = new System.Drawing.Point(90, 121);
            this.txt_cat_name.Name = "txt_cat_name";
            this.txt_cat_name.Size = new System.Drawing.Size(120, 22);
            this.txt_cat_name.TabIndex = 4;
            // 
            // btn_cat_delete
            // 
            this.btn_cat_delete.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_cat_delete.FlatAppearance.BorderSize = 0;
            this.btn_cat_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cat_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cat_delete.ForeColor = System.Drawing.Color.White;
            this.btn_cat_delete.Location = new System.Drawing.Point(9, 41);
            this.btn_cat_delete.Name = "btn_cat_delete";
            this.btn_cat_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_cat_delete.TabIndex = 2;
            this.btn_cat_delete.Text = "Delete";
            this.btn_cat_delete.UseVisualStyleBackColor = false;
            // 
            // btn_cat_add
            // 
            this.btn_cat_add.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_cat_add.FlatAppearance.BorderSize = 0;
            this.btn_cat_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cat_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cat_add.ForeColor = System.Drawing.Color.White;
            this.btn_cat_add.Location = new System.Drawing.Point(8, 12);
            this.btn_cat_add.Name = "btn_cat_add";
            this.btn_cat_add.Size = new System.Drawing.Size(75, 23);
            this.btn_cat_add.TabIndex = 1;
            this.btn_cat_add.Text = "Add";
            this.btn_cat_add.UseVisualStyleBackColor = false;
            // 
            // lbx_cat_all
            // 
            this.lbx_cat_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_cat_all.FormattingEnabled = true;
            this.lbx_cat_all.ItemHeight = 16;
            this.lbx_cat_all.Location = new System.Drawing.Point(90, 12);
            this.lbx_cat_all.Name = "lbx_cat_all";
            this.lbx_cat_all.Size = new System.Drawing.Size(120, 84);
            this.lbx_cat_all.TabIndex = 0;
            // 
            // panel_storage
            // 
            this.panel_storage.BackColor = System.Drawing.Color.Transparent;
            this.panel_storage.Controls.Add(this.listBox1);
            this.panel_storage.Location = new System.Drawing.Point(205, 508);
            this.panel_storage.Name = "panel_storage";
            this.panel_storage.Size = new System.Drawing.Size(795, 424);
            this.panel_storage.TabIndex = 6;
            this.panel_storage.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 14);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1695, 994);
            this.Controls.Add(this.panel_storage);
            this.Controls.Add(this.panel_categories);
            this.Controls.Add(this.panel_elements);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_main_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.panel_main_title.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_elements.ResumeLayout(false);
            this.panel_elements.PerformLayout();
            this.panel_categories.ResumeLayout(false);
            this.panel_categories.PerformLayout();
            this.panel_storage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main_title;
        private System.Windows.Forms.Button btn_main_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_elements;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_elements;
        private System.Windows.Forms.Button btn_elements_cat_del;
        private System.Windows.Forms.Button btn_elements_cat_add;
        private System.Windows.Forms.Label lbl_length;
        private System.Windows.Forms.TextBox txt_elements_length;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_elements_width;
        private System.Windows.Forms.TextBox txt_elements_height;
        private System.Windows.Forms.ListBox lbx_elements_used_cat;
        private System.Windows.Forms.ListBox lbx_elements_all_cat;
        private System.Windows.Forms.RichTextBox rtx_elements_desc;
        private System.Windows.Forms.TextBox txt_element_name;
        private System.Windows.Forms.Panel panel_categories;
        private System.Windows.Forms.Label lbl_cat_name;
        private System.Windows.Forms.TextBox txt_cat_name;
        private System.Windows.Forms.Button btn_cat_delete;
        private System.Windows.Forms.Button btn_cat_add;
        private System.Windows.Forms.ListBox lbx_cat_all;
        private System.Windows.Forms.Panel panel_storage;
        private System.Windows.Forms.ListBox listBox1;
    }
}