using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.Model
{
    public class ConsultaCRMJson
    {
        public string total { get; set; }
        public IList<ItemJson> item { get; set; }
        
    }
}
