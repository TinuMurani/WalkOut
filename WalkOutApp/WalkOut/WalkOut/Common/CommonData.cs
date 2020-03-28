using System.IO;

namespace WalkOut.Common
{
    public class CommonData
    {
        private static readonly string _fileName = "data.db";
        
        public static readonly string _folderPath = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "WalkOut" + Java.IO.File.Separator;
        
        internal static readonly string _dbPath = Path.Combine(_folderPath, _fileName);
    }
}
