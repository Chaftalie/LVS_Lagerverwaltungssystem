namespace LVS_Lagerverwaltungssystem_PCUI
{
    partial class Form_BarcodesTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pbxCodeOutputQR = new System.Windows.Forms.PictureBox();
            this.pbcCodeOutputDM = new System.Windows.Forms.PictureBox();
            this.pbxCodeOutputAztec = new System.Windows.Forms.PictureBox();
            this.pbxCodeOutputC128 = new System.Windows.Forms.PictureBox();
            this.pbxCodeOutputPDF417 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcCodeOutputDM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputAztec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputC128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputPDF417)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbxCodeOutputQR);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR-Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbcCodeOutputDM);
            this.groupBox2.Location = new System.Drawing.Point(219, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 200);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DataMatrix";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbxCodeOutputAztec);
            this.groupBox3.Location = new System.Drawing.Point(426, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 200);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aztec Code";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbxCodeOutputPDF417);
            this.groupBox4.Location = new System.Drawing.Point(13, 218);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PDF417";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pbxCodeOutputC128);
            this.groupBox5.Location = new System.Drawing.Point(322, 218);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Code128";
            // 
            // pbxCodeOutputQR
            // 
            this.pbxCodeOutputQR.Location = new System.Drawing.Point(7, 20);
            this.pbxCodeOutputQR.Name = "pbxCodeOutputQR";
            this.pbxCodeOutputQR.Size = new System.Drawing.Size(187, 174);
            this.pbxCodeOutputQR.TabIndex = 0;
            this.pbxCodeOutputQR.TabStop = false;
            this.pbxCodeOutputQR.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCodeOutputQR_Paint);
            // 
            // pbcCodeOutputDM
            // 
            this.pbcCodeOutputDM.Location = new System.Drawing.Point(7, 20);
            this.pbcCodeOutputDM.Name = "pbcCodeOutputDM";
            this.pbcCodeOutputDM.Size = new System.Drawing.Size(187, 174);
            this.pbcCodeOutputDM.TabIndex = 0;
            this.pbcCodeOutputDM.TabStop = false;
            this.pbcCodeOutputDM.Paint += new System.Windows.Forms.PaintEventHandler(this.pbcCodeOutputDM_Paint);
            // 
            // pbxCodeOutputAztec
            // 
            this.pbxCodeOutputAztec.Location = new System.Drawing.Point(7, 20);
            this.pbxCodeOutputAztec.Name = "pbxCodeOutputAztec";
            this.pbxCodeOutputAztec.Size = new System.Drawing.Size(187, 174);
            this.pbxCodeOutputAztec.TabIndex = 0;
            this.pbxCodeOutputAztec.TabStop = false;
            this.pbxCodeOutputAztec.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCodeOutputAztec_Paint);
            // 
            // pbxCodeOutputC128
            // 
            this.pbxCodeOutputC128.Location = new System.Drawing.Point(7, 20);
            this.pbxCodeOutputC128.Name = "pbxCodeOutputC128";
            this.pbxCodeOutputC128.Size = new System.Drawing.Size(290, 74);
            this.pbxCodeOutputC128.TabIndex = 0;
            this.pbxCodeOutputC128.TabStop = false;
            this.pbxCodeOutputC128.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCodeOutputC128_Paint);
            // 
            // pbxCodeOutputPDF417
            // 
            this.pbxCodeOutputPDF417.Location = new System.Drawing.Point(7, 20);
            this.pbxCodeOutputPDF417.Name = "pbxCodeOutputPDF417";
            this.pbxCodeOutputPDF417.Size = new System.Drawing.Size(290, 74);
            this.pbxCodeOutputPDF417.TabIndex = 0;
            this.pbxCodeOutputPDF417.TabStop = false;
            this.pbxCodeOutputPDF417.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCodeOutputPDF417_Paint);
            // 
            // Form_BarcodesTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_BarcodesTest";
            this.Text = "Form_BarcodesTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcCodeOutputDM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputAztec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputC128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCodeOutputPDF417)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbxCodeOutputQR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbcCodeOutputDM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pbxCodeOutputAztec;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbxCodeOutputPDF417;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pbxCodeOutputC128;
    }
}