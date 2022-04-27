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
        public static byte[] ImageToByteArray(String ImgPath)
        {
            byte[] ImageData = null;
            FileStream Stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(Stream);

            ImageData = binaryReader.ReadBytes((int)Stream.Length);
            return ImageData;
        }
        public static Image ByteArrayToImage(byte[] source)
        {
            MemoryStream memoryStream = new MemoryStream(source);
            Image image = Image.FromStream(memoryStream);
            return image;
        }
    }
}