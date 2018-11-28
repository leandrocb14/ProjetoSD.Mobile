using ProjetoSD.Mobile.BLL;
using ProjetoSD.Mobile.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Propriedades
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
        #endregion

        #region Construtor
        public LoginViewModel()
        {
            this.LoginBLL = new LoginBLL();
            this.EntrarCommand = new Command(async () =>
            {
                try
                {
                    int CodeUser = await LoginBLL.VerificaAutenticacao(email, senha);
                    MessagingCenter.Send<string>(Convert.ToString(CodeUser), "EntrarCommand");                    
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch (EmailInvalidoException ex2)
                {
                    LimparCampoEmail();
                    LimparCampoSenha();
                    MessagingCenter.Send<string>(ex2.Message, "Exception");
                }
                catch (UsuarioNotFoundException ex3)
                {
                    LimparCampoSenha();
                    MessagingCenter.Send<string>(ex3.Message, "Exception");
                }
            });
            this.CadastrarContaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "CadastrarContaCommand");
            });
        }
        #endregion

        #region Métodos Privados
        private void LimparCampoEmail()
        {
            Email = "";           
        }
        private void LimparCampoSenha()
        {
            Senha = "";
        }
        #endregion
    }
}
