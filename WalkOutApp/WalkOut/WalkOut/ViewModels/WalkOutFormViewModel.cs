using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WalkOut.ViewModels
{
    public class WalkOutFormViewModel : BindableBase
    {
        private int _id = 1;
        private string _numePrenume;
        private string _dataNasterii;
        private string _adresa;
        private string _locDeplasare;
        private bool _interesProfesional;
        private bool _asigurareBunuri;
        private bool _asistentaMedicala;
        private bool _motiveJustificate;
        private bool _activitateFizica;
        private bool _activitatiAgricole;
        private bool _donareSange;
        private bool _scopuriUmanitare;
        private bool _comertAgricole;
        private bool _bunuriActivitateProfesionala;
        private string _dataDeplasarii;

        public WalkOutFormViewModel()
        {

        }

        public int Id
        {
            get { return _id; }
            set 
            { 
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string NumePrenume
        {
            get { return _numePrenume; }
            set 
            {
                _numePrenume = value;
                RaisePropertyChanged(nameof(NumePrenume));
            }
        }

        public string DataNasterii
        {
            get { return _dataNasterii; }
            set 
            {
                _dataNasterii = value;
                RaisePropertyChanged(nameof(DataNasterii));
            }
        }

        public string Adresa
        {
            get { return _adresa; }
            set 
            {
                _adresa = value;
                RaisePropertyChanged(nameof(Adresa));
            }
        }

        public string LocDeplasare
        {
            get { return _locDeplasare; }
            set 
            {
                _locDeplasare = value;
                RaisePropertyChanged(nameof(LocDeplasare));
            }
        }

        public bool InteresProfesional
        {
            get { return _interesProfesional; }
            set
            {
                _interesProfesional = value;
                RaisePropertyChanged(nameof(InteresProfesional));
            }
        }

        public bool AsigurareBunuri
        {
            get { return _asigurareBunuri; }
            set 
            {
                _asigurareBunuri = value;
                RaisePropertyChanged(nameof(AsigurareBunuri));
            }
        }

        public bool AsistentaMedicala
        {
            get { return _asistentaMedicala; }
            set 
            {
                _asistentaMedicala = value;
                RaisePropertyChanged(nameof(AsistentaMedicala));
            }
        }

        public bool MotiveJustificate
        {
            get { return _motiveJustificate; }
            set 
            {
                _motiveJustificate = value;
                RaisePropertyChanged(nameof(MotiveJustificate));
            }
        }

        public bool ActivitateFizica
        {
            get { return _activitateFizica; }
            set
            {
                _activitateFizica = value;
                RaisePropertyChanged(nameof(ActivitateFizica));
            }
        }

        public bool ActivitatiAgricole
        {
            get { return _activitatiAgricole; }
            set 
            {
                _activitatiAgricole = value;
                RaisePropertyChanged(nameof(ActivitatiAgricole));
            }
        }

        public bool DonareSange
        {
            get { return _donareSange; }
            set 
            {
                _donareSange = value;
                RaisePropertyChanged(nameof(DonareSange));
            }
        }

        public bool ScopuriUmanitare
        {
            get { return _scopuriUmanitare; }
            set 
            {
                _scopuriUmanitare = value;
                RaisePropertyChanged(nameof(ScopuriUmanitare));
            }
        }

        public bool ComertAgricole
        {
            get { return _comertAgricole; }
            set 
            {
                _comertAgricole = value;
                RaisePropertyChanged(nameof(ComertAgricole));
            }
        }

        public bool BunuriActivitateProfesionala
        {
            get { return _bunuriActivitateProfesionala; }
            set 
            {
                _bunuriActivitateProfesionala = value;
                RaisePropertyChanged(nameof(BunuriActivitateProfesionala));
            }
        }

        public string DataDeplasarii
        {
            get { return _dataDeplasarii; }
            set 
            { 
                _dataDeplasarii = value;
                RaisePropertyChanged(nameof(DataDeplasarii));
            }
        }

    }
}
