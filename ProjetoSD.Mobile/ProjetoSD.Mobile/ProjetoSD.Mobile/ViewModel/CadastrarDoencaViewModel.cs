using ProjetoSD.Mobile.BLL;
using ProjetoSD.Mobile.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class CadastrarDoencaViewModel : BaseViewModel
    {

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

        public CadastrarDoencaViewModel(int idMedico)
        {
            this.IdMedico = idMedico;
            this.CadastrarDoencaBLL = new CadastrarDoencaBLL();
            this.CadastrarCommand = new Command(async () =>
            {
                try
                {
                    await this.CadastrarDoencaBLL.Adiciona(IdMedico, oQueEh, Tratamento, Evite);
                    LimparCampoOQueEh();
                    LimparCampoTratamento();
                    LimparCampoEvite();
                    MessagingCenter.Send<string>("Doença cadastrada com sucesso!", "SucessoCadastro");
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
            });
        }

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
    }
}
