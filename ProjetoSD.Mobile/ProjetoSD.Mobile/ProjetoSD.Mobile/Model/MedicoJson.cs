using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Model
{
    public class MedicoJson
    { 
        public string CRM { get; set; }
        public string Nome { get; set; }
        public int UF { get; set; }
        public string Profissao { get; set; }
        public UsuarioJson Usuario { get; set; }

    }
}
