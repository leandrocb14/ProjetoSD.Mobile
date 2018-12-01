using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.BLL
{
    public class UFBLL
    {
        /// <summary>
        /// Método utilizado para listar todas as UF do Brasil.
        /// </summary>
        /// <returns></returns>
        public List<string> ListarUFs()
        {
            Array ufs = (Array)Enum.GetValues(typeof(UF));
            List<string> listaUFs = new List<string>();
            foreach (var q in ufs)
            {
                listaUFs.Add(q.ToString());
            }
            return listaUFs;
        }
    }
}
