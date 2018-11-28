using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class ConfirmacaoSenhaSemReferenciaException : Exception
    {
        public ConfirmacaoSenhaSemReferenciaException(string message) : base(message)
        {

        }
    }
}
