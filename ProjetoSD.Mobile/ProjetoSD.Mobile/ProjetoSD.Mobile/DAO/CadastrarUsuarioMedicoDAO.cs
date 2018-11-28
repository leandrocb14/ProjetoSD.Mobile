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
    public class CadastrarUsuarioMedicoDAO
    {
        #region Propriedades
        private static string Controller = "Usuario";
        private string Url = string.Format($"{Host.Url}/{Controller}");
        #endregion

        #region Métodos Públicos
        public async Task CadastraUsuario(string crm, string nome, UF uF, string profissao, string email, string senha)
        {            
            HttpClient cliente = new HttpClient();
            string action = "CadastraUsuario";
            string parameters = $"crm={crm}&nome={nome}&uF={uF}&profissao={profissao}&email={email}&senha={senha}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await cliente.PostAsync(request, new StringContent(""));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var messageRequestNotFound = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(messageRequestNotFound.Message);
            }
        }
        #endregion
    }
}
