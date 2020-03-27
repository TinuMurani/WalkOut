using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using WalkOut.Models;

namespace WalkOut.SqlDataAccess
{
    public static class SqlCommands
    {
        private static readonly string _fileName = "data.db";
        private static readonly string _folderPath = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "WalkOut" + Java.IO.File.Separator;
        public static readonly string DbPath = Path.Combine(_folderPath, _fileName);

        public static void CreateExternalFolder()
        {
            if (Directory.Exists(_folderPath))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        public static void CreateDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath))
            {
                connection.CreateTable<FormModel>();
            }
        }
    }
}
