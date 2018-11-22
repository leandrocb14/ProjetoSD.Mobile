using ProjetoSD.Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoSD.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            this.BindingContext = new LoginViewModel();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<string>(this, "Exception", (msg) =>
            {
                DisplayAlert("Erro", msg, "OK");
            });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<string>(this, "EntrarCommand");
            MessagingCenter.Unsubscribe<string>(this, "CadastrarContaCommand");
            MessagingCenter.Unsubscribe<string>(this, "Exception");
            base.OnDisappearing();
        }
    }
}