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
            this.panel_main_title.SuspendLayout();
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
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.panel_main_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.panel_main_title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main_title;
        private System.Windows.Forms.Button btn_main_close;
    }
}