using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WalkOut.Models
{
    [Table ("Data")]
    public class FormModel
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string NumePrenume { get; set; }
        
        [NotNull]
        public string DataNasterii { get; set; }
        
        [NotNull]
        public string Adresa { get; set; }
        
        [NotNull]
        public string LocDeplasare { get; set; }
        
        public bool InteresProfesional { get; set; }
        public bool AsigurareBunuri { get; set; }
        public bool AsistentaMedicala { get; set; }
        public bool MotiveJustificate { get; set; }
        public bool ActivitateFizica { get; set; }
        public bool ActivitatiAgricole { get; set; }
        public bool DonareSange { get; set; }
        public bool ScopuriUmanitare { get; set; }
        public bool ComertAgricole { get; set; }
        public bool BunuriActivitateProfesionala { get; set; }

        [NotNull]
        public string DataDeplasarii { get; set; }
    }
}
