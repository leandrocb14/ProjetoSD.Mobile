using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjetoSD.Mobile.CustomComponent;
using ProjetoSD.Mobile.Droid;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyLabelVersion), typeof(CustomLabelRenderer))]
namespace ProjetoSD.Mobile.Droid
{    
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);            
            Control.Text = typeof(App).GetTypeInfo().Assembly.GetName().Version.ToString();
        }
    }
}