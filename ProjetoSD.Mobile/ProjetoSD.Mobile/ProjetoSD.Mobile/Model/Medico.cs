using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Model
{
    public class Medico
    {
        public int Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }
        public string Profissao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
