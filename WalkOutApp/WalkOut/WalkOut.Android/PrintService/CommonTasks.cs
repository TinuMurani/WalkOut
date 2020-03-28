using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace WalkOut.Droid.PrintService
{
    internal class CommonTasks
    {
        public static void WriteFileToStorage(string fileName)
        {
            AssetManager assets = MainActivity.AppContext.Assets;

            if (new File(Common.CommonData._folderPath + fileName).Exists())
            {
                return;
            }

            try
            {
                var input = assets.Open(fileName);
                var output = new FileOutputStream(Common.CommonData._folderPath + fileName);
                byte[] buffer = new byte[8 * 1024];

                int length;

                while ((length = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, length);
                }

            }
            catch (FileNotFoundException e)
            {
                e.PrintStackTrace();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
        }
    }
}