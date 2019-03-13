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
            this.pbxBarcodeOutput = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcodeOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBarcodeOutput
            // 
            this.pbxBarcodeOutput.Location = new System.Drawing.Point(330, 67);
            this.pbxBarcodeOutput.Name = "pbxBarcodeOutput";
            this.pbxBarcodeOutput.Size = new System.Drawing.Size(276, 274);
            this.pbxBarcodeOutput.TabIndex = 0;
            this.pbxBarcodeOutput.TabStop = false;
            this.pbxBarcodeOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxBarcodeOutput_Paint);
            // 
            // Form_BarcodesTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbxBarcodeOutput);
            this.Name = "Form_BarcodesTest";
            this.Text = "Form_BarcodesTest";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcodeOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBarcodeOutput;
    }
}