using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;

namespace LVS_Webtools
{
    class Program
    {
        static void Main(string[] args)
        {
            

            if (args.Length > 0)
            {
                string sourceImage = args[0];
                //string sourceImage = "test.png";
                string codeData;
                string codeType;

                BarcodeReader barcodeReader = new BarcodeReader();

                Bitmap codeImg = (Bitmap)Image.FromFile(sourceImage);
                codeData = barcodeReader.Decode(codeImg)?.Text;
                codeType = Convert.ToString(barcodeReader.Decode(codeImg)?.BarcodeFormat);

                Console.WriteLine(codeData);
                Console.WriteLine(codeType);
            }
            else Console.WriteLine("Error");

            return;
        }
    }
}
