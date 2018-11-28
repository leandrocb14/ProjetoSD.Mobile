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
    public class CadastrarDoencaDAO
    {
        private static string Controller = "Doenca";
        private string Url = string.Format($"{Host.Url}/{Controller}");

        public async Task Cadastrar(int idMedico, string nomeDoenca, string descricao, string profilaxia)
        {
            HttpClient httpClient = new HttpClient();
            string action = "Adiciona";
            string parameters = $"idMedico={idMedico}&oQueEh={nomeDoenca}&tratamento={descricao}&evite={profilaxia}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await httpClient.PostAsync(request, new StringContent(""));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var ErrorMessageRequest = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(ErrorMessageRequest.Message);
            }
        }
    }
}
