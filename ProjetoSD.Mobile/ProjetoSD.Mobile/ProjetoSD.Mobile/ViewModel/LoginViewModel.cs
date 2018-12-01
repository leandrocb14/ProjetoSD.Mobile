using ProjetoSD.Mobile.BLL;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.View;
using Rg.Plugins.Popup.Services;
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
                    await PopupNavigation.Instance.PushAsync(new PopupLoadingView());
                    int CodeUser = await LoginBLL.VerificaAutenticacao(email, senha);
                    MessagingCenter.Send<string>(Convert.ToString(CodeUser), "EntrarCommand");                    
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessasingCenterSendError(ex.Message);
                }
                catch (EmailInvalidoException ex)
                {
                    LimparCampoEmail();
                    LimparCampoSenha();
                    MessasingCenterSendError(ex.Message);
                }
                catch (UsuarioNotFoundException ex)
                {
                    LimparCampoSenha();
                    MessasingCenterSendError(ex.Message);
                }
                catch(Exception ex)
                {
                    MessasingCenterSendError(ex.Message);
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
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
        private void MessasingCenterSendError(string messageErro)
        {
            MessagingCenter.Send<string>(messageErro, "Exception");
        }
        #endregion
    }
}
