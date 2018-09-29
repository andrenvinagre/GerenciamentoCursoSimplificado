using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppAndre.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string usuario;
        public string Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public Command LogoutCommand { get; }

        #region Services
        private readonly INavigationService navigationService;
        #endregion

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Tela Principal";
            LogoutCommand = new Command(LogoutAction);
            this.navigationService = navigationService;
        }

        private async void LogoutAction()
        {
            await navigationService.NavigateAsync("app:///NavigationPage/LoginPage");
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Usuario = parameters["usuario"] as string;
        }
    }
}
