using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class UsuarioNotFoundException : Exception
    {
        public UsuarioNotFoundException(string message) : base(message)
        {

        }
    }
}
