using Android.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WalkOut.Common
{
    internal class ImageConverter
    {
        public static async Task<byte[]> ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static void ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex)
            {
                Log.Debug("WalkOut", ex.Message);
            }
        }
    }
}
