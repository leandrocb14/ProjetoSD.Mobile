using ProjetoSD.Mobile.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class CadastrarUsuarioMedicoViewModel
    {
        private UFBLL UFBLL { get; set; }
        public ICommand EfetuarCadastrarContaCommand { get; set; }
        public ICommand VoltarLoginCommand { get; set; }

        public List<string> ListarUFs { get { return this.UFBLL.ListarUFs(); } }

        public CadastrarUsuarioMedicoViewModel()
        {
            this.UFBLL = new UFBLL();
            this.EfetuarCadastrarContaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "EfetuarCadastroContaCommand");
            });
            this.VoltarLoginCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "GoToLogin");
            });
        }
    }
}
