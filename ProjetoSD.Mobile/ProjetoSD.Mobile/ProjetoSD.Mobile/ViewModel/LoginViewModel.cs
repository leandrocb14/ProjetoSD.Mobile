using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoSD.Mobile.ViewModel
{
    public class LoginViewModel
    {
        public ICommand EntrarCommand { get; set; }
        public ICommand CadastrarContaCommand { get; set; }

        public LoginViewModel()
        {
            this.EntrarCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "EntrarCommand");
            });
            this.CadastrarContaCommand = new Command(() =>
            {
                MessagingCenter.Send<string>("", "CadastrarContaCommand");
            });
        }
    }
}
