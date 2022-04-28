using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Zen.Barcode;

namespace Startupx.Helpers
{
    class Barcode
    {
       public void GenerateBarcode(string barCode, System.Windows.Controls.Image img_barcode, System.Windows.Controls.Label lb_barcode)
        {
            lb_barcode.Content = barCode;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                ImageSource img = ConvertImage(brCode.Draw(barCode, 60));
                img_barcode.Source = img;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lb_barcode.Content = "Error!";

            }
        }

        public static System.Windows.Media.ImageSource ConvertImage(System.Drawing.Image image)
        {
            try
            {
                if (image != null)
                {
                    var bitmap = new System.Windows.Media.Imaging.BitmapImage();
                    bitmap.BeginInit();
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                    bitmap.StreamSource = memoryStream;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch { }
            return null;
        }
    }
}
