using ProjetoSD.Mobile.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.ViewModel
{
    public class AlterarDadosContaViewModel
    {
        private UFBLL UFBLL { get; set; }
        public List<string> ListarUFs { get { return this.UFBLL.ListarUFs(); } }
        public AlterarDadosContaViewModel()
        {
            this.UFBLL = new UFBLL();
        }
    }
}
