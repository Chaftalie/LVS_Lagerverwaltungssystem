using LVS_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using ZXing;
using System.Drawing.Imaging;

namespace LVS_WebInterface
{
    public partial class frame_camCapture : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
            {
               
                try
                {
                    Image img = ImageStuff.GetImageFromString(Request["imgOut"]);
                    Bitmap image = new Bitmap(img);

                    BarcodeReader barcodeReader = new BarcodeReader();
          
                    lbl1.Text = barcodeReader.Decode(image)?.Text;
                    lbl2.Text = Convert.ToString(barcodeReader.Decode(image)?.BarcodeFormat);
                }
                catch(Exception ex) { }

                
                
            }
        }

    }
}