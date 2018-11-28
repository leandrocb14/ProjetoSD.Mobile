using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class CamposNaoModificadosException : Exception
    {
        public CamposNaoModificadosException(string message) : base(message)
        {

        }
    }
}
