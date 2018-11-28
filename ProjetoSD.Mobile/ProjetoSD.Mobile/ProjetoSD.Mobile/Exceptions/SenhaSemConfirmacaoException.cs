using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class SenhaSemConfirmacaoException : Exception
    {
        public SenhaSemConfirmacaoException(string message) : base(message)
        {

        }
    }
}
