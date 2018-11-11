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
        public MasterDetailView()
        {
            this.BindingContext = new MasterDetailViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); MessagingCenter.Subscribe<string>(this, "MasterDescollapse", (msg) =>
            {
                IsPresented = false;
            });
        }
    }
}