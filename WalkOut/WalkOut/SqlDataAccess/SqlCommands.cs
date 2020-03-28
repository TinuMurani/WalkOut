using System.Collections.Generic;
using System.IO;
using SQLite;
using WalkOut.Models;

namespace WalkOut.SqlDataAccess
{
    public static class SqlCommands
    {
        private static readonly string _selectCommand = "select Id, NumePrenume, DataNasterii, Adresa, LocDeplasare, " +
            "InteresProfesional, AsigurareBunuri, AsistentaMedicala, MotiveJustificate, ActivitateFizica, ActivitatiAgricole, " +
            "DonareSange, ScopuriUmanitare, ComertAgricole, BunuriActivitateProfesionala, DataDeclaratiei from Data where Id=1;";

        public static void CreateExternalFolder()
        {
            if (Directory.Exists(Common.CommonData._folderPath))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(Common.CommonData._folderPath);
            }
        }

        public static void CreateDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Common.CommonData._dbPath))
            {
                connection.CreateTable<FormModel>();
            }
        }

        public static void SaveForm(FormModel form)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Common.CommonData._dbPath))
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
            using (SQLiteConnection connection = new SQLiteConnection(Common.CommonData._dbPath))
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
