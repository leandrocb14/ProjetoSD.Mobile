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
		public AlterarDadosContaView ()
		{            
            this.BindingContext = new AlterarDadosContaViewModel();
			InitializeComponent ();
		}
	}
}