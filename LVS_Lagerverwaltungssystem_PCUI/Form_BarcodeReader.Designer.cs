namespace LVS_Lagerverwaltungssystem_PCUI
{
    partial class Form_BarcodeReader
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
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbxCamOutput = new System.Windows.Forms.PictureBox();
            this.tmr_16ms = new System.Windows.Forms.Timer(this.components);
            this.txbBarcodeOutput = new System.Windows.Forms.TextBox();
            this.txbBarcodeType = new System.Windows.Forms.TextBox();
            this.btnResetCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCamOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCamOutput
            // 
            this.pbxCamOutput.Location = new System.Drawing.Point(12, 12);
            this.pbxCamOutput.Name = "pbxCamOutput";
            this.pbxCamOutput.Size = new System.Drawing.Size(776, 353);
            this.pbxCamOutput.TabIndex = 0;
            this.pbxCamOutput.TabStop = false;
            // 
            // tmr_16ms
            // 
            this.tmr_16ms.Enabled = true;
            this.tmr_16ms.Interval = 16;
            this.tmr_16ms.Tick += new System.EventHandler(this.tmr_16ms_Tick);
            // 
            // txbBarcodeOutput
            // 
            this.txbBarcodeOutput.Location = new System.Drawing.Point(12, 371);
            this.txbBarcodeOutput.Name = "txbBarcodeOutput";
            this.txbBarcodeOutput.Size = new System.Drawing.Size(376, 20);
            this.txbBarcodeOutput.TabIndex = 1;
            // 
            // txbBarcodeType
            // 
            this.txbBarcodeType.Location = new System.Drawing.Point(12, 398);
            this.txbBarcodeType.Name = "txbBarcodeType";
            this.txbBarcodeType.Size = new System.Drawing.Size(376, 20);
            this.txbBarcodeType.TabIndex = 2;
            // 
            // btnResetCapture
            // 
            this.btnResetCapture.Location = new System.Drawing.Point(394, 371);
            this.btnResetCapture.Name = "btnResetCapture";
            this.btnResetCapture.Size = new System.Drawing.Size(114, 47);
            this.btnResetCapture.TabIndex = 3;
            this.btnResetCapture.Text = "Neue Aufnahme";
            this.btnResetCapture.UseVisualStyleBackColor = true;
            this.btnResetCapture.Click += new System.EventHandler(this.btnResetCapture_Click);
            // 
            // Form_BarcodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetCapture);
            this.Controls.Add(this.txbBarcodeType);
            this.Controls.Add(this.txbBarcodeOutput);
            this.Controls.Add(this.pbxCamOutput);
            this.Name = "Form_BarcodeReader";
            this.Text = "Form_BarcodeReader";
            ((System.ComponentModel.ISupportInitialize)(this.pbxCamOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pbxCamOutput;
        private System.Windows.Forms.Timer tmr_16ms;
        private System.Windows.Forms.TextBox txbBarcodeOutput;
        private System.Windows.Forms.TextBox txbBarcodeType;
        private System.Windows.Forms.Button btnResetCapture;
    }
}