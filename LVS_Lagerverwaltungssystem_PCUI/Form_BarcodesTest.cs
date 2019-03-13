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
        private string encodeText = "Datamatrix is the best code and YOU CAN'T ARGUE WITH THAT BITCH";

        public Form_BarcodesTest()
        {
            InitializeComponent();
        }

        private void pbxCodeOutputQR_Paint(object sender, PaintEventArgs e)
        {
            Image codeImage = XDCodes.CreateImage(encodeText, XDCodes.CodeTypes.QRCode);

            float scaleFactorY = (float)pbxCodeOutputQR.Height / (float)codeImage.Height;
            float scaleFactorX = (float)pbxCodeOutputQR.Width / (float)codeImage.Width;
            float scaleFactor;
            if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
            else scaleFactor = scaleFactorX;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            e.Graphics.DrawImage(codeImage, 1, 1);
        }

        private void pbcCodeOutputDM_Paint(object sender, PaintEventArgs e)
        {
            Image codeImage = XDCodes.CreateImage(encodeText, XDCodes.CodeTypes.DataMatrix);

            float scaleFactorY = (float)pbcCodeOutputDM.Height / (float)codeImage.Height;
            float scaleFactorX = (float)pbcCodeOutputDM.Width / (float)codeImage.Width;
            float scaleFactor;
            if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
            else scaleFactor = scaleFactorX;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            e.Graphics.DrawImage(codeImage, 1, 1);
        }

        private void pbxCodeOutputAztec_Paint(object sender, PaintEventArgs e)
        {
            Image codeImage = XDCodes.CreateImage(encodeText, XDCodes.CodeTypes.Aztec);

            float scaleFactorY = (float)pbxCodeOutputAztec.Height / (float)codeImage.Height;
            float scaleFactorX = (float)pbxCodeOutputAztec.Width / (float)codeImage.Width;
            float scaleFactor;
            if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
            else scaleFactor = scaleFactorX;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            e.Graphics.DrawImage(codeImage, 1, 1);
        }

        private void pbxCodeOutputPDF417_Paint(object sender, PaintEventArgs e)
        {
            Image codeImage = XDCodes.CreateImage(encodeText, XDCodes.CodeTypes.PDF417);

            float scaleFactorY = (float)pbxCodeOutputPDF417.Height / (float)codeImage.Height;
            float scaleFactorX = (float)pbxCodeOutputPDF417.Width / (float)codeImage.Width;
            float scaleFactor;
            if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
            else scaleFactor = scaleFactorX;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            e.Graphics.DrawImage(codeImage, 1, 1);
        }

        private void pbxCodeOutputC128_Paint(object sender, PaintEventArgs e)
        {
            if (encodeText.Length < 80)
            {
                Image codeImage = XDCodes.CreateImage(encodeText, XDCodes.CodeTypes.Code128);

                float scaleFactorY = (float)pbxCodeOutputC128.Height / (float)codeImage.Height;
                float scaleFactorX = (float)pbxCodeOutputC128.Width / (float)codeImage.Width;
                float scaleFactor;
                if (scaleFactorX > scaleFactorY) scaleFactor = scaleFactorY;
                else scaleFactor = scaleFactorX;

                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
                e.Graphics.DrawImage(codeImage, 1, 1);
            }
        }
    }
}
