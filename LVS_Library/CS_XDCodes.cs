using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.Datamatrix;
using ZXing.PDF417;

namespace LVS_Library
{
    public class XDCodes
    {
        public enum CodeTypes
        {
            Code128,
            QRCode,
            DataMatrix,
            Aztec,
            PDF417
        }
        public static Image CreateImage(string data, CodeTypes type)
        {
            Image codeImage = null;
            Bitmap result = null;
            BarcodeWriter writer = null;

            switch (type)
            {
                case CodeTypes.Code128:
                    writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new EncodingOptions
                        {
                            PureBarcode = true,
                            Height = 20
                        }
                    };
                    result = writer.Write(data);
                    break;
                case CodeTypes.PDF417:
                    writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.PDF_417,
                        Options = new PDF417EncodingOptions
                        {
                            Margin = 0
                        }
                    };
                    result = writer.Write(data);
                    break;
                case CodeTypes.DataMatrix:
                        writer = new BarcodeWriter
                        {
                            Format = BarcodeFormat.DATA_MATRIX,
                            Options = new DatamatrixEncodingOptions
                            {
                                PureBarcode = true,
                                SymbolShape = ZXing.Datamatrix.Encoder.SymbolShapeHint.FORCE_SQUARE,
                                Height = 300,
                                Width = 300,
                                Margin = 1
                                
                            }
                        };
                        result = writer.Write(data);
                        break;
                case CodeTypes.QRCode:
                        writer = new BarcodeWriter
                        {
                            Format = BarcodeFormat.QR_CODE,
                            Options = new EncodingOptions
                            {
                                Height = 300,
                                Width = 300,
                                Margin = 1
                            }
                        };
                        result = writer.Write(data);
                        break;
                case CodeTypes.Aztec:
                        writer = new BarcodeWriter
                        {
                            Format = BarcodeFormat.AZTEC,
                            Options = new EncodingOptions
                            {
                                Height = 300,
                                Width = 300,
                                Margin = 1
                            }
                        };
                        result = writer.Write(data);
                        break;
                default: throw new ApplicationException("*** Codetype not Implemented! ***");
            }

            var barcodeBitmap = new Bitmap(result);
            codeImage = (Image)barcodeBitmap;

            return codeImage;
        }
    }
}
