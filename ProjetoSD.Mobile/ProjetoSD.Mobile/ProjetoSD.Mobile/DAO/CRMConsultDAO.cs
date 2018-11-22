using Newtonsoft.Json;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.DAO
{
    public class CRMConsultDAO
    {
        private string Uri = "https://www.consultacrm.com.br/api/index.php";
        private string KeyToConnection = "4058087596";

        public async Task<ConsultaCRMJson> ConsultaUFCRM(UF uF, string crm)
        {
            HttpClient httpClient = new HttpClient();
            string parameters = $"tipo=crm&uf={uF}&q={crm}&chave={KeyToConnection}&destino=json";
            string request = $"{Uri}?{parameters}";
            var response = await httpClient.GetAsync(request);
            return JsonConvert.DeserializeObject<ConsultaCRMJson>(await response.Content.ReadAsStringAsync());            
        }
    }
}
