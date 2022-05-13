using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing;

namespace IMDB.Controllers
{
    public class ImageConversion
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageIn.Save(memoryStream, imageIn.RawFormat);
                return memoryStream.ToArray();
            }
        }
        public static Image ByteArrayToImage(byte[] source)
        {
            MemoryStream memoryStream = new MemoryStream(source);
            Image image = Image.FromStream(memoryStream);
            return image;
        }
    }
}