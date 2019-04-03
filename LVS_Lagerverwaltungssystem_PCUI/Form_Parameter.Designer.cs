namespace LVS_Lagerverwaltungssystem_PCUI
{
    partial class Form_Parameter
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_DB = new System.Windows.Forms.TabPage();
            this.btn_check_connection = new System.Windows.Forms.Button();
            this.btn_resett = new System.Windows.Forms.Button();
            this.btn_save_DB = new System.Windows.Forms.Button();
            this.tBx_Login_Password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBx_Login_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBx_DB_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBx_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBx_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_par_close = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_DB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_DB);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_DB
            // 
            this.tabPage_DB.BackColor = System.Drawing.Color.LightSlateGray;
            this.tabPage_DB.Controls.Add(this.btn_check_connection);
            this.tabPage_DB.Controls.Add(this.btn_resett);
            this.tabPage_DB.Controls.Add(this.btn_save_DB);
            this.tabPage_DB.Controls.Add(this.tBx_Login_Password);
            this.tabPage_DB.Controls.Add(this.label5);
            this.tabPage_DB.Controls.Add(this.tBx_Login_Name);
            this.tabPage_DB.Controls.Add(this.label4);
            this.tabPage_DB.Controls.Add(this.tBx_DB_Name);
            this.tabPage_DB.Controls.Add(this.label3);
            this.tabPage_DB.Controls.Add(this.tBx_Port);
            this.tabPage_DB.Controls.Add(this.label2);
            this.tabPage_DB.Controls.Add(this.tBx_IP);
            this.tabPage_DB.Controls.Add(this.label1);
            this.tabPage_DB.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DB.Name = "tabPage_DB";
            this.tabPage_DB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DB.Size = new System.Drawing.Size(792, 419);
            this.tabPage_DB.TabIndex = 0;
            this.tabPage_DB.Text = "Datenbank";
            // 
            // btn_check_connection
            // 
            this.btn_check_connection.Location = new System.Drawing.Point(13, 393);
            this.btn_check_connection.Name = "btn_check_connection";
            this.btn_check_connection.Size = new System.Drawing.Size(136, 23);
            this.btn_check_connection.TabIndex = 12;
            this.btn_check_connection.Text = "Verbindung prüfen";
            this.btn_check_connection.UseVisualStyleBackColor = true;
            this.btn_check_connection.Click += new System.EventHandler(this.btn_check_connection_Click);
            // 
            // btn_resett
            // 
            this.btn_resett.Location = new System.Drawing.Point(649, 364);
            this.btn_resett.Name = "btn_resett";
            this.btn_resett.Size = new System.Drawing.Size(136, 23);
            this.btn_resett.TabIndex = 11;
            this.btn_resett.Text = "Zurücksetzen";
            this.btn_resett.UseVisualStyleBackColor = true;
            this.btn_resett.Click += new System.EventHandler(this.btn_resett_Click);
            // 
            // btn_save_DB
            // 
            this.btn_save_DB.Location = new System.Drawing.Point(649, 393);
            this.btn_save_DB.Name = "btn_save_DB";
            this.btn_save_DB.Size = new System.Drawing.Size(136, 23);
            this.btn_save_DB.TabIndex = 10;
            this.btn_save_DB.Text = "Speichern";
            this.btn_save_DB.UseVisualStyleBackColor = true;
            this.btn_save_DB.Click += new System.EventHandler(this.btn_save_DB_Click);
            // 
            // tBx_Login_Password
            // 
            this.tBx_Login_Password.Location = new System.Drawing.Point(107, 111);
            this.tBx_Login_Password.Name = "tBx_Login_Password";
            this.tBx_Login_Password.Size = new System.Drawing.Size(678, 20);
            this.tBx_Login_Password.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Login Passwort";
            // 
            // tBx_Login_Name
            // 
            this.tBx_Login_Name.Location = new System.Drawing.Point(107, 85);
            this.tBx_Login_Name.Name = "tBx_Login_Name";
            this.tBx_Login_Name.Size = new System.Drawing.Size(678, 20);
            this.tBx_Login_Name.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Login Name";
            // 
            // tBx_DB_Name
            // 
            this.tBx_DB_Name.Location = new System.Drawing.Point(107, 59);
            this.tBx_DB_Name.Name = "tBx_DB_Name";
            this.tBx_DB_Name.Size = new System.Drawing.Size(678, 20);
            this.tBx_DB_Name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datenbank Name";
            // 
            // tBx_Port
            // 
            this.tBx_Port.Location = new System.Drawing.Point(107, 33);
            this.tBx_Port.Name = "tBx_Port";
            this.tBx_Port.Size = new System.Drawing.Size(678, 20);
            this.tBx_Port.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // tBx_IP
            // 
            this.tBx_IP.Location = new System.Drawing.Point(107, 7);
            this.tBx_IP.Name = "tBx_IP";
            this.tBx_IP.Size = new System.Drawing.Size(678, 20);
            this.tBx_IP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP / Domain";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSlateGray;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_par_close);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 23);
            this.panel1.TabIndex = 1;
            // 
            // btn_par_close
            // 
            this.btn_par_close.FlatAppearance.BorderSize = 0;
            this.btn_par_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_par_close.Location = new System.Drawing.Point(768, 0);
            this.btn_par_close.Name = "btn_par_close";
            this.btn_par_close.Size = new System.Drawing.Size(32, 23);
            this.btn_par_close.TabIndex = 2;
            this.btn_par_close.Text = "X";
            this.btn_par_close.UseVisualStyleBackColor = true;
            this.btn_par_close.Click += new System.EventHandler(this.btn_par_close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Settings: Parameters";
            // 
            // Form_Parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Parameter";
            this.Text = "Parameter";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_DB.ResumeLayout(false);
            this.tabPage_DB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_DB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_resett;
        private System.Windows.Forms.Button btn_save_DB;
        private System.Windows.Forms.TextBox tBx_Login_Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBx_Login_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBx_DB_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBx_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBx_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_check_connection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_par_close;
        private System.Windows.Forms.Label label6;
    }
}