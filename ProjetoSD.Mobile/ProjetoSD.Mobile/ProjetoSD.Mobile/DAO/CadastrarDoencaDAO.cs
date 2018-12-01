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
    public class CadastrarDoencaDAO : INavigationFeature
    {
        #region Propriedades
        public string Controller { get { return "Doenca"; } }
        public string Url { get { return string.Format($"{Host.Url}/{Controller}"); } }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Método utilizado para cadastrar uma nova doença.
        /// </summary>
        /// <param name="idMedico">Representa o código de quem identificou.</param>
        /// <param name="nomeDoenca">Representa o nome da doença.</param>
        /// <param name="descricao">Representa o nome da descrição do <paramref name="nomeDoenca"/>.</param>
        /// <param name="profilaxia">Representa as maneiras de previnir o <paramref name="nomeDoenca"/>.</param>
        /// <returns></returns>
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
        #endregion
    }
}
