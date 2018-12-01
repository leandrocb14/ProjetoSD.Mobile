using ProjetoSD.Mobile.BLL;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.Model;
using ProjetoSD.Mobile.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class AlterarDadosContaViewModel : BaseViewModel
    {

        #region Propriedades
        private UFBLL UFBLL { get; set; }
        private AlterarDadosContaBLL AlterarDadosContaBLL;

        private string crm;
        public string CRM
        {
            get { return crm; }
            set
            {
                OnPropertyChanged();
                crm = value;
            }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                OnPropertyChanged();
                nome = value;
            }
        }

        public List<string> ListarUFs { get { return this.UFBLL.ListarUFs(); } }

        private string profissao;
        public string Profissao
        {
            get { return profissao; }
            set
            {
                OnPropertyChanged();
                profissao = value;
            }
        }

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


        private string novaSenha;
        public string NovaSenha
        {
            get { return novaSenha; }
            set
            {
                OnPropertyChanged();
                novaSenha = value;
            }
        }

        private string cNovaSenha;
        public string CNovaSenha
        {
            get { return cNovaSenha; }
            set
            {
                OnPropertyChanged();
                cNovaSenha = value;
            }
        }

        private int uF;
        public int UF
        {
            get { return uF; }
            set
            {
                OnPropertyChanged();
                uF = value;
            }
        }

        public ICommand AlterarCommand { get; set; }
        #endregion

        #region Construtores
        public AlterarDadosContaViewModel()
        {

        }
        #endregion

        #region Métodos Publico
        public AlterarDadosContaViewModel(int idMedico)
        {
            this.UFBLL = new UFBLL();
            this.AlterarDadosContaBLL = new AlterarDadosContaBLL(idMedico);

            Task task = Task.Factory.StartNew(() =>
            {
                var medicoJson = AlterarDadosContaBLL.BuscaInformacoesUsuario();
                ArmazenaInformacoes(medicoJson);
            });

            this.AlterarCommand = new Command(async () =>
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new PopupLoadingView());
                    await this.AlterarDadosContaBLL.AlterarDadosUsuario(Profissao, novaSenha, cNovaSenha);
                    LimpaCampoSenha();
                    LimpaCampoCSenha();
                    MessagingCenter.Send<string>("Alteração realizada com sucesso!", "SucessoAlteracao");
                    await PopupNavigation.Instance.PopAsync();
                }catch(CampoNullOrEmptyException ex)
                {
                    MessagingCenterSendErro(ex.Message);                    
                }
                catch (ConfirmacaoSenhaSemReferenciaException ex)
                {
                    LimpaCampoCSenha();
                    MessagingCenterSendErro(ex.Message);
                }
                catch (SenhaSemConfirmacaoException ex)
                {
                    LimpaCampoSenha();
                    MessagingCenterSendErro(ex.Message);
                }
                catch(ConfirmationPasswordDifferentException ex)
                {
                    LimpaCampoSenha();
                    LimpaCampoCSenha();
                    MessagingCenterSendErro(ex.Message);
                }
                catch (Exception ex)
                {
                    MessagingCenterSendErro(ex.Message);
                }
            });
        }        
        #endregion

        #region Métodos Privados
        private void ArmazenaInformacoes(Task<MedicoJson> medicoJson)
        {
            var mj = medicoJson.Result;
            this.CRM = mj.CRM;
            this.Nome = mj.Nome;
            this.Profissao = mj.Profissao;
            this.Email = mj.Usuario.Email;
            this.UF = mj.UF;
        }

        private void LimpaCampoSenha()
        {
            this.NovaSenha = "";
        }
        private void LimpaCampoCSenha()
        {
            this.CNovaSenha = "";
        }

        private void MessagingCenterSendErro(string messageErro)
        {
            MessagingCenter.Send<string>(messageErro, "Exception");
        }
        #endregion
    }
}
