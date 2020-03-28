using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WalkOut.Common;
using WalkOut.Models;

namespace WalkOut.ViewModels
{
    public class WalkOutFormViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;
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
        private string _dataDeclaratiei = Common.CommonMethods.DateToString(DateTime.Now);
        private DelegateCommand _saveForm;
        private DelegateCommand _loadPDF;
        private DelegateCommand _salvareSemnatura;

        public WalkOutFormViewModel(IPageDialogService pageDialogService)
        {
            if (SqlDataAccess.SqlCommands.VerificareFormular())
            {
                NumePrenume = SqlDataAccess.SqlCommands.SelectForm()[0].NumePrenume;
                DataNasterii = SqlDataAccess.SqlCommands.SelectForm()[0].DataNasterii;
                Adresa = SqlDataAccess.SqlCommands.SelectForm()[0].Adresa;
                LocDeplasare = SqlDataAccess.SqlCommands.SelectForm()[0].LocDeplasare;
                InteresProfesional = SqlDataAccess.SqlCommands.SelectForm()[0].InteresProfesional;
                AsigurareBunuri = SqlDataAccess.SqlCommands.SelectForm()[0].AsigurareBunuri;
                AsistentaMedicala = SqlDataAccess.SqlCommands.SelectForm()[0].AsistentaMedicala;
                MotiveJustificate = SqlDataAccess.SqlCommands.SelectForm()[0].MotiveJustificate;
                ActivitateFizica = SqlDataAccess.SqlCommands.SelectForm()[0].ActivitateFizica;
                ActivitatiAgricole = SqlDataAccess.SqlCommands.SelectForm()[0].ActivitatiAgricole;
                DonareSange = SqlDataAccess.SqlCommands.SelectForm()[0].DonareSange;
                ScopuriUmanitare = SqlDataAccess.SqlCommands.SelectForm()[0].ScopuriUmanitare;
                ComertAgricole = SqlDataAccess.SqlCommands.SelectForm()[0].ComertAgricole;
                BunuriActivitateProfesionala = SqlDataAccess.SqlCommands.SelectForm()[0].BunuriActivitateProfesionala;
            }

            _pageDialogService = pageDialogService;
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

        public string DataDeclaratiei
        {
            get { return _dataDeclaratiei; }
            set
            {
                _dataDeclaratiei = Common.CommonMethods.DateToString(DateTime.Now);
                RaisePropertyChanged(nameof(DataDeclaratiei));
            }
        }

        public DelegateCommand SaveForm => _saveForm ?? (_saveForm = new DelegateCommand(SalvareFormular));

        private void SalvareFormular()
        {
            if (ValidareFormular())
            {

                FormModel form = new FormModel()
                {
                    Id = Id,
                    NumePrenume = NumePrenume.Trim(),
                    DataNasterii = DataNasterii.Trim(),
                    Adresa = Adresa.Trim(),
                    LocDeplasare = LocDeplasare.Trim(),
                    InteresProfesional = InteresProfesional,
                    AsigurareBunuri = AsigurareBunuri,
                    AsistentaMedicala = AsistentaMedicala,
                    MotiveJustificate = MotiveJustificate,
                    ActivitateFizica = ActivitateFizica,
                    ActivitatiAgricole = ActivitatiAgricole,
                    DonareSange = DonareSange,
                    ScopuriUmanitare = ScopuriUmanitare,
                    ComertAgricole = ComertAgricole,
                    BunuriActivitateProfesionala = BunuriActivitateProfesionala,
                    DataDeclaratiei = DataDeclaratiei
                };

                SqlDataAccess.SqlCommands.SaveForm(form);
            }
            else
            {
                return;
            } 
        }

        private bool ValidareFormular()
        {
            bool output = false;

            if (InteresProfesional || AsigurareBunuri || AsistentaMedicala
                || AsistentaMedicala || MotiveJustificate || ActivitateFizica
                || ActivitatiAgricole || DonareSange || ScopuriUmanitare
                || ComertAgricole || BunuriActivitateProfesionala) 
            {
                output = true;
            }
            else
            {
                output = false;
                _pageDialogService.DisplayAlertAsync("Ooops!", "Selecteaza cel putin un tip de activitate", "OK");
            }


            if (string.IsNullOrWhiteSpace(NumePrenume) || string.IsNullOrWhiteSpace(DataNasterii) || string.IsNullOrWhiteSpace(Adresa) ||
                string.IsNullOrWhiteSpace(LocDeplasare))
            {
                output = false;
                _pageDialogService.DisplayAlertAsync("Ooops!", "Completeaza toate campurile", "OK");
            }
            else
            {
                output = true;
            }

            return output;
        }

        public DelegateCommand LoadPDF => _loadPDF ?? (_loadPDF = new DelegateCommand(GenerarePDF));

        private void GenerarePDF()
        {
            FormModel form = new FormModel();

            if (SqlDataAccess.SqlCommands.VerificareFormular()) 
            {
                form = SqlDataAccess.SqlCommands.SelectForm()[0];
            }
            else
            {
                _pageDialogService.DisplayAlertAsync("Ooops!", "Nu ai salvat datele", "OK");
                return;
            }

            try
            {
                Xamarin.Forms.DependencyService.Get<IPrinterService>().GeneratePDF(form);
            }
            catch (Exception ex)
            {
                _pageDialogService.DisplayAlertAsync("Uh-Oh!", ex.Message, "OK");
            }
        }

        public Func<Task<byte[]>> SignatureFromStream { get; set; }
        public byte[] Semnatura { get; set; }

        public DelegateCommand SalvareSemnatura => _salvareSemnatura ?? (_salvareSemnatura = new DelegateCommand(SaveSignatureToFile));

        private async void SaveSignatureToFile()
        {
            try
            {
                Semnatura = await SignatureFromStream();

                if (Semnatura != null)
                {
                    ImageConverter.ByteArrayToFile(CommonData._folderPath + "img.png", Semnatura);
                }
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Well shit...", ex.Message, "OK");
            }
        }
    }
}
