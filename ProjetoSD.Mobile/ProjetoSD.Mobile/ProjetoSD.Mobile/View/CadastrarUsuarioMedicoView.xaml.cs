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
    public partial class CadastrarUsuarioMedicoView : ContentPage
    {
        public CadastrarUsuarioMedicoView()
        {
            this.BindingContext = new CadastrarUsuarioMedicoViewModel();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<string>(this, "Exception", (msg) =>
            {
                DisplayAlert("Erro", msg, "OK");
            });
            MessagingCenter.Subscribe<string>(this, "EfetuarCadastroContaCommand", async (msg) =>
            {
                await DisplayAlert("", "Usuário cadastrado com sucesso!", "OK");
                MessagingCenter.Send<string>("", "GoToLogin");
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {            
            MessagingCenter.Unsubscribe<string>(this, "EfetuarCadastroContaCommand");
            MessagingCenter.Unsubscribe<string>(this, "GoToLogin");
            MessagingCenter.Unsubscribe<string>(this, "Exception");
            base.OnDisappearing();
        }
    }
}