using Rg.Plugins.Popup.Pages;
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
	public partial class PopupLoadingView : PopupPage
	{
		public PopupLoadingView ()
		{
			InitializeComponent ();
		}

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}