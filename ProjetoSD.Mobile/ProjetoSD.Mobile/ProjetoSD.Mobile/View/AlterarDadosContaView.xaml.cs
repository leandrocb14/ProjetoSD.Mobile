using ProjetoSD.Mobile.Model;
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
    public partial class AlterarDadosContaView : ContentPage
    {
        public AlterarDadosContaViewModel alterarDadosContaView = new AlterarDadosContaViewModel();
        public AlterarDadosContaView(int idMedico)
        {
            this.alterarDadosContaView = new AlterarDadosContaViewModel(idMedico);
            this.BindingContext = alterarDadosContaView;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "Exception", (msg) =>
            {
                DisplayAlert("Erro", msg, "OK");
            });
            MessagingCenter.Subscribe<string>(this, "SucessoAlteracao", async (msg) =>
            {
                await DisplayAlert("Sucesso", msg, "OK");
                await Navigation.PopAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Exception");
            MessagingCenter.Unsubscribe<string>(this, "SucessoAlteracao");
        }
    }
}