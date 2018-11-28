using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class CampoNullOrEmptyException : Exception
    {

        public CampoNullOrEmptyException(string message) : base(message)
        {

        }
    }
}
