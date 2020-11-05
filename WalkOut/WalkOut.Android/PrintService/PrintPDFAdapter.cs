using System;
using Android.OS;
using Android.Print;
using Android.Util;
using Java.IO;

namespace WalkOut.Droid.PrintService
{
    public class PrintPDFAdapter : PrintDocumentAdapter
    {
        private readonly string _filePath;

        public PrintPDFAdapter(string filePath)
        {
            _filePath = filePath;
        }


        public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras)
        {
            if (cancellationSignal.IsCanceled)
            {
                callback.OnLayoutCancelled();
            }
            else
            {
                PrintDocumentInfo.Builder builder = new PrintDocumentInfo.Builder(_filePath);
                builder.SetContentType(PrintContentType.Document)
                    .SetPageCount(PrintDocumentInfo.PageCountUnknown)
                    .Build();
                callback.OnLayoutFinished(builder.Build(), !newAttributes.Equals(oldAttributes));
            }
        }

        public override void OnWrite(PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
        {
            InputStream input = null;
            OutputStream output = null;

            try
            {
                File file = new File(_filePath);
                input = new FileInputStream(file);
                output = new FileOutputStream(destination.FileDescriptor);

                byte[] buffer = new byte[8 * 1024];
                int length;
                while ((length = input.Read(buffer)) >= 0 && !cancellationSignal.IsCanceled)
                {
                    output.Write(buffer, 0, length);
                }

                if (cancellationSignal.IsCanceled)
                {
                    callback.OnWriteCancelled();
                }
                else
                {
                    callback.OnWriteFinished(new PageRange[] { PageRange.AllPages });
                }

            }
            catch (Exception e)
            {
                callback.OnWriteFailed(e.Message);
            }
            finally
            {
                try
                {
                    input.Close();
                    output.Close();
                }
                catch (IOException e)
                {
                    Log.Error("WalkOut", e.Message);
                }
            }
        }
    }
}