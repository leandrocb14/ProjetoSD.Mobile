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
    public partial class CadastrarDoencaView : ContentPage
    {
        public CadastrarDoencaView(int idMedico)
        {
            this.BindingContext = new CadastrarDoencaViewModel(idMedico);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "Exception", (msg) =>
            {
                DisplayAlert("Erro", msg, "OK");
            });
            MessagingCenter.Subscribe<string>(this, "SucessoCadastro", async (msg) =>
            {
                await DisplayAlert("Sucesso", msg, "OK");
                await Navigation.PopAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Exception");
        }
    }
}