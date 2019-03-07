namespace LVS_Lagerverwaltungssystem_PCUI
{
    partial class Form_Load
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_load = new System.Windows.Forms.Label();
            this.panel_loadbody = new System.Windows.Forms.Panel();
            this.panel_load_mover = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_loadbody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 23);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_load
            // 
            this.lbl_load.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_load.AutoSize = true;
            this.lbl_load.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_load.Location = new System.Drawing.Point(192, 255);
            this.lbl_load.Name = "lbl_load";
            this.lbl_load.Size = new System.Drawing.Size(172, 16);
            this.lbl_load.TabIndex = 1;
            this.lbl_load.Text = "Loading, please wait...";
            this.lbl_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_loadbody
            // 
            this.panel_loadbody.BackColor = System.Drawing.Color.LightGray;
            this.panel_loadbody.Controls.Add(this.panel_load_mover);
            this.panel_loadbody.Location = new System.Drawing.Point(13, 226);
            this.panel_loadbody.Name = "panel_loadbody";
            this.panel_loadbody.Size = new System.Drawing.Size(525, 7);
            this.panel_loadbody.TabIndex = 2;
            // 
            // panel_load_mover
            // 
            this.panel_load_mover.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel_load_mover.Location = new System.Drawing.Point(441, 0);
            this.panel_load_mover.Name = "panel_load_mover";
            this.panel_load_mover.Size = new System.Drawing.Size(83, 10);
            this.panel_load_mover.TabIndex = 3;
            // 
            // Form_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(550, 280);
            this.ControlBox = false;
            this.Controls.Add(this.panel_loadbody);
            this.Controls.Add(this.lbl_load);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Load";
            this.Load += new System.EventHandler(this.Form_Load_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_loadbody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_load;
        private System.Windows.Forms.Panel panel_loadbody;
        private System.Windows.Forms.Panel panel_load_mover;
    }
}