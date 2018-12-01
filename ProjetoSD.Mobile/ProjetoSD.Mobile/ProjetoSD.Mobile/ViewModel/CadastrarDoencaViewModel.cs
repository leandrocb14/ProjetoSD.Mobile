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
    public class CadastrarDoencaViewModel : BaseViewModel
    {

        #region Propriedades
        private CadastrarDoencaBLL CadastrarDoencaBLL;
        private int IdMedico;

        private string oQueEh;
        public string OQueEh
        {
            get { return oQueEh; }
            set
            {
                OnPropertyChanged();
                oQueEh = value;
            }
        }

        private string tratamento;
        public string Tratamento
        {
            get { return tratamento; }
            set
            {
                OnPropertyChanged();
                tratamento = value;
            }
        }

        private string evite;
        public string Evite
        {
            get { return evite; }
            set
            {
                OnPropertyChanged();
                evite = value;
            }
        }

        public ICommand CadastrarCommand { get; set; }
        #endregion

        #region Construtor
        public CadastrarDoencaViewModel(int idMedico)
        {
            this.IdMedico = idMedico;
            this.CadastrarDoencaBLL = new CadastrarDoencaBLL(idMedico);
            this.CadastrarCommand = new Command(async () =>
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new PopupLoadingView());
                    await this.CadastrarDoencaBLL.Adiciona(oQueEh, Tratamento, Evite);
                    LimparCampoOQueEh();
                    LimparCampoTratamento();
                    LimparCampoEvite();
                    MessagingCenter.Send<string>("Doença cadastrada com sucesso!", "SucessoCadastro");
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessagingCenterSendErro(ex.Message);
                }
                catch (Exception ex)
                {
                    MessagingCenterSendErro(ex.Message);
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
                }
            });
        }        
        #endregion

        #region Métodos Privados
        private void LimparCampoOQueEh()
        {
            this.OQueEh = "";
        }
        private void LimparCampoTratamento()
        {
            this.Tratamento = "";
        }
        private void LimparCampoEvite()
        {
            this.Evite = "";
        }
        private void MessagingCenterSendErro(string messageErro)
        {
            MessagingCenter.Send<string>(messageErro, "Exception");
        }
        #endregion
    }
}
