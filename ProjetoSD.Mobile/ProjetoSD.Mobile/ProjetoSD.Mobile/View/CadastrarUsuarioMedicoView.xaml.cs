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

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<string>(this, "EfetuarCadastroContaCommand");
            MessagingCenter.Unsubscribe<string>(this, "GoToLogin");
            base.OnDisappearing();
        }
    }
}