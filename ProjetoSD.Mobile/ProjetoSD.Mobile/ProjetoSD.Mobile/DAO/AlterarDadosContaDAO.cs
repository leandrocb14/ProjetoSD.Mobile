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
    public class AlterarDadosContaDAO
    {
        private static string Controller = "Usuario";
        private string Url = string.Format($"{Host.Url}/{Controller}");

        public async Task<MedicoJson> BuscaInformacoesUsuario(int idMedico)
        {
            HttpClient httpClient = new HttpClient();
            string action = "BuscaInformacoesUsuario";
            string parameters = $"idMedico={idMedico}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await httpClient.GetAsync(request);
            var messageRequest = JsonConvert.DeserializeObject<MedicoJson>(await response.Content.ReadAsStringAsync());
            return messageRequest;
        }

        public async Task AtualizaProfissao(int idMedico, string novaProfissao)
        {
            HttpClient httpClient = new HttpClient();
            string action = "AlterarProfissaoUsuario";
            string parameters = $"idMedico={idMedico}&novaProfissao={novaProfissao}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await httpClient.PostAsync(request, new StringContent(""));
            if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                var messageRequestErro = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(messageRequestErro.Message);
            }            
        }

        public async Task AtualizaSenha(int idMedico, string novaSenha)
        {
            HttpClient httpClient = new HttpClient();
            string action = "AtualizaSenha";
            string parameters = $"idMedico={idMedico}&novaSenha={novaSenha}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await httpClient.PostAsync(request, new StringContent(""));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var messageRequestErro = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(messageRequestErro.Message);
            }
        }
    }
}
