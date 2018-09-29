using AppAndre.Util;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppAndre.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
        #region Campos
        private string email;
        private string senha;
        #endregion

        #region Propriedades
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Senha
        {
            get => senha;
            set => SetProperty(ref senha, value);
        }

        public Command LoginCommand { get; }
        #endregion

        #region Services
        private readonly IPageDialogService dialogService;
        private readonly INavigationService navigationService;
        #endregion

        #region Ctor
        public LoginPageViewModel(IPageDialogService dialogService, INavigationService navigationService)
        {
            LoginCommand = new Command(LoginAction);
            this.dialogService = dialogService;
            this.navigationService = navigationService;
        }
        #endregion

        private async void LoginAction()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                await dialogService.DisplayAlertAsync("Atenção", "E-MAIL deve ser informado.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Senha))
            {
                await dialogService.DisplayAlertAsync("Atenção", "SENHA deve ser informada.", "OK");
                return;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);

            if (!match.Success)
            {
                await dialogService.DisplayAlertAsync("Atenção", "E-MAIL informado não é válido.", "OK");
                return;
            }

            var loginSuccessful = await Web.Login(Email, Senha);

            if (loginSuccessful == null)
            {
                await dialogService.DisplayAlertAsync("Atenção", "Problema ao realizar login.", "OK");
            }
            //Sucesso
            else if (loginSuccessful.codigo == 0)
            {
                //await dialogService.DisplayAlertAsync("Atenção", $"Usuário {Usuario} logado com sucesso", "OK");
                var parameters = new NavigationParameters
                {
                    { "usuario", loginSuccessful.aluno.nome }
                };

                await navigationService.NavigateAsync("app:///NavigationPage/MainPage", parameters);
            }
            else
            {
                await dialogService.DisplayAlertAsync("Atenção", loginSuccessful.mensagem, "OK");
            }                
        }

        private bool UserCanLogin()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Senha);
        }
    }
}
