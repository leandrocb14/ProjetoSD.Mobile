using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Model
{
    public interface INavigationFeature
    {        
        string Controller
        {
            get;
        }

        string Url
        {
            get;
        }

    }
}
