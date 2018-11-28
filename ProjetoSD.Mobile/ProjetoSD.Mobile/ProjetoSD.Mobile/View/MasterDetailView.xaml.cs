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
    public partial class MasterDetailView : MasterDetailPage
    {
        
        public MasterDetailView(int idMedico)
        {
            this.BindingContext = new MasterDetailViewModel();
            Master = new MasterView();
            Detail = new NavigationPage(new DetailView(idMedico));
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "MasterDescollapse", (msg) =>
            {
                IsPresented = false;
            });            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
        }
    }
}