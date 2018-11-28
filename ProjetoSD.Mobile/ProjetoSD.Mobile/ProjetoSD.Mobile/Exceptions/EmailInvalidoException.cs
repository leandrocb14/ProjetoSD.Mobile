using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class EmailInvalidoException : Exception
    {
        public EmailInvalidoException(string message) : base(message)
        {

        }
    }
}
