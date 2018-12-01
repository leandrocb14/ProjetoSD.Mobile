using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class MasterViewModel
    {
        #region Propriedades
        public ICommand CadastrarDoencaCommand { get; set; }
        public ICommand AlterarDadosContaCommand { get; set; }
        public ICommand SobreCommand { get; set; }
        public ICommand SairCommand { get; set; }
        #endregion

        #region Construtor
        public MasterViewModel()
        {
            this.CadastrarDoencaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "CadastrarDoencaCommand");
            });
            this.AlterarDadosContaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "AlterarDadosContaCommand");
            });
            this.SobreCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "SobreCommand");
            });
            this.SairCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "GoToLogin");
            });
        }
        #endregion
    }
}
