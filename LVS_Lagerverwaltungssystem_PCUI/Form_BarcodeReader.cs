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

        public Form_BarcodeReader()
        {
            InitializeComponent();

            

            Bitmap image = capture.QueryFrame().Bitmap;

            pbxCamOutput.Image = image;

        }

        private void tmr_16ms_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap image = capture.QueryFrame().Bitmap;
                pbxCamOutput.Image.Dispose();

                pbxCamOutput.Image = image;


                // create a barcode reader instance
                var barcodeReader = new BarcodeReader();

                // create an in memory bitmap
                var barcodeBitmap = image;

                // decode the barcode from the in memory bitmap
                var barcodeResult = barcodeReader.Decode(barcodeBitmap);

                // output results to console

                txbBarcodeOutput.Text = barcodeResult?.Text;
                txbBarcodeType.Text = Convert.ToString(barcodeResult?.BarcodeFormat);

                //Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
                //Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");

                if (txbBarcodeOutput.Text != "")
                {
                    Console.Beep(1800, 100);
                    Console.Beep(1500, 200);
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
