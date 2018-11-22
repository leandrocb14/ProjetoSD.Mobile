using ProjetoSD.Mobile.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                OnPropertyChanged();
                email = value;
            }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                OnPropertyChanged();
                senha = value;
            }
        }
        public ICommand EntrarCommand { get; set; }
        public ICommand CadastrarContaCommand { get; set; }
        private LoginBLL LoginBLL;

        public LoginViewModel()
        {
            this.LoginBLL = new LoginBLL();
            this.EntrarCommand = new Command(async () =>
            {
                try
                {
                    await LoginBLL.VerificaAutenticacao(email, senha);
                    MessagingCenter.Send<string>("", "EntrarCommand");
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }               
            });
            this.CadastrarContaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "CadastrarContaCommand");
            });
        }
    }
}
