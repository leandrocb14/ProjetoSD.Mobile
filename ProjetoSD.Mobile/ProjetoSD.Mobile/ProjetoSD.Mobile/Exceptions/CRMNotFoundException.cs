using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Exceptions
{
    public class CRMNotFoundException : Exception
    {
        public CRMNotFoundException(string message) : base(message)
        {

        }
    }
}
