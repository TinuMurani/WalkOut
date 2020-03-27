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
        private static readonly string DbPath = Path.Combine(_folderPath, _fileName);

        private static readonly string _selectCommand = "select Id, NumePrenume, DataNasterii, Adresa, LocDeplasare, " +
            "InteresProfesional, AsigurareBunuri, AsistentaMedicala, MotiveJustificate, ActivitateFizica, ActivitatiAgricole, " +
            "DonareSange, ScopuriUmanitare, ComertAgricole, BunuriActivitateProfesionala from Data where Id=1;";

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

        public static void SaveForm(FormModel form)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath))
            {
                if (SelectForm()?.Count == 0)
                {
                    connection.Insert(form);
                }
                else
                {
                    connection.Update(form);
                }
            }
        }

        public static List<FormModel> SelectForm()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath))
            {
                var output = connection.Query<FormModel>(_selectCommand);
                
                return output;
            }
        }

        public static bool VerificareFormular()
        {
            if (SelectForm()?.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
