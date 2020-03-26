using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WalkOut.Models
{
    [Table ("Data")]
    public class FormModel
    {
        public int Id { get; set; }
        public string NumePrenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Adresa { get; set; }
        public string ListaLocDeplasare { get; set; }
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
        public DateTime DataDeplasarii { get; set; }
    }
}
