using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkOut.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _openForm;
        
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Walk Outside";
            _navigationService = navigationService;
        }


        public DelegateCommand OpenForm => _openForm ?? (_openForm = new DelegateCommand(DeschideFormular));

        private void DeschideFormular()
        {
            _navigationService.NavigateAsync("WalkOutForm");
        }
    }
}
