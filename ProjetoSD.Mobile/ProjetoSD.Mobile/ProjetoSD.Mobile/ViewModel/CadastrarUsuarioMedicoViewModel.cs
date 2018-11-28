using ProjetoSD.Mobile.BLL;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class CadastrarUsuarioMedicoViewModel : BaseViewModel
    {
        #region Propriedades
        private CadastrarUsuarioMedicoBLL CadastrarUsuarioMedicoBLL;        
        private UFBLL UFBLL { get; set; }

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

        private int indexUF;
        public int IndexUF
        {
            get { return indexUF; }
            set
            {
                OnPropertyChanged();
                indexUF = value;
            }
        }

        private UF UF
        {
            get { return (UF)(Enum.GetValues(typeof(UF)).GetValue(indexUF)); }
        }

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

        private string confirmarSenha;
        public string ConfirmarSenha
        {
            get { return confirmarSenha; }
            set
            {
                OnPropertyChanged();
                confirmarSenha = value;
            }
        }

        public ICommand EfetuarCadastroContaCommand { get; set; }
        public ICommand VoltarLoginCommand { get; set; }
        public ICommand ConsultarUFCRM { get; set; }

        public List<string> ListarUFs { get { return this.UFBLL.ListarUFs(); } }
        #endregion

        #region Construtores
        public CadastrarUsuarioMedicoViewModel()
        {
            this.UFBLL = new UFBLL();
            this.CadastrarUsuarioMedicoBLL = new CadastrarUsuarioMedicoBLL();
            this.ConsultarUFCRM = new Command(async () =>
            {
                try
                {
                    var response = await this.CadastrarUsuarioMedicoBLL.ConsultaUFCRM(UF, crm);
                    PreencheDadosRetornadosDaConsultaUFCRM(response);
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch (CRMNotFoundException ex)
                {
                    LimparCampoCRM();
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch(Exception ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                
            });
            this.EfetuarCadastroContaCommand = new Command(async () =>
            {
                try
                {
                    await this.CadastrarUsuarioMedicoBLL.CadastraUsuario(crm, nome, UF, profissao, email, senha, confirmarSenha);
                    MessagingCenter.Send<string>("", "EfetuarCadastroContaCommand");
                }
                catch (CampoNullOrEmptyException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch(ConfirmationPasswordDifferentException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch(ArgumentException ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }
                catch(Exception ex)
                {
                    MessagingCenter.Send<string>(ex.Message, "Exception");
                }

            });
            this.VoltarLoginCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "GoToLogin");
            });
        }
        #endregion

        #region Métodos Privados
        private void LimparCampoCRM()
        {
            this.CRM = "";
        }
        private void PreencheDadosRetornadosDaConsultaUFCRM(ConsultaCRMJson consultaCRMJson)
        {
            Nome = consultaCRMJson.item[0].nome;
            Profissao = consultaCRMJson.item[0].profissao;
        }
        #endregion

    }
}