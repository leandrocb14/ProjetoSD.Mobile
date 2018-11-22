using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoStatus TipoStatus { get; set; }

        public Medico Medico { get; set; }
    }
}
