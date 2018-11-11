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
		public CadastrarDoencaView ()
		{
            this.BindingContext = new CadastrarUsuarioMedicoViewModel();
			InitializeComponent ();
		}
	}
}