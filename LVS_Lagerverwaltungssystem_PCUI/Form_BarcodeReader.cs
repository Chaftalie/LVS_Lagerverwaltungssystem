using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    public partial class Form_BarcodeReader : Form
    {
        VideoCapture capture = new VideoCapture();
        BarcodeReader barcodeReader = new BarcodeReader();

        public Form_BarcodeReader()
        {
            InitializeComponent();

            

            Bitmap image = capture.QueryFrame().Bitmap;

            pbxCamOutput.Image = image;

            pbxCamOutput.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

        }

        private void tmr_16ms_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap image = capture.QueryFrame().Bitmap;
                pbxCamOutput.Image.Dispose();
                pbxCamOutput.Image = image;
                pbxCamOutput.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                txbBarcodeOutput.Text = barcodeReader.Decode(image)?.Text;
                txbBarcodeType.Text = Convert.ToString(barcodeReader.Decode(image)?.BarcodeFormat);

                if (txbBarcodeOutput.Text != "")
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\airhorn.wav");
                    player.Play();
                    tmr_16ms.Stop();
                }
            }
            catch(Exception ex)
            {
                txbBarcodeOutput.Text = "Fehler";
                Console.Beep(1000, 100);
                Console.Beep(1000, 200);
                tmr_16ms.Stop();
            }
            

        }

        private void btnResetCapture_Click(object sender, EventArgs e)
        {
            tmr_16ms.Start();
            txbBarcodeOutput.Text = "";
            txbBarcodeType.Text = "";
        }
    }
}
