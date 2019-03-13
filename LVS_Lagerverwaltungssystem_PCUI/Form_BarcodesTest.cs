using LVS_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    public partial class Form_BarcodesTest : Form
    {
        public Form_BarcodesTest()
        {
            InitializeComponent();
        }

        private void pbxBarcodeOutput_Paint(object sender, PaintEventArgs e)
        {

            Image codeImage = XDCodes.CreateImage("Hallo i bims da Tobi", XDCodes.CodeTypes.QRCode);

            float scaleFactorY = (float)pbxBarcodeOutput.Height / (float)codeImage.Height;
            float scaleFactorX = (float)pbxBarcodeOutput.Width / (float)codeImage.Width;
            float scaleFactor;
            if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
            else scaleFactor = scaleFactorX;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            e.Graphics.DrawImage(codeImage, 1, 1);

            
        }
    }
}
