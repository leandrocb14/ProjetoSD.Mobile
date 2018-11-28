using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class ConfirmationPasswordDifferentException : Exception
    {
        public ConfirmationPasswordDifferentException(string message) : base(message)
        {

        }
    }
}
