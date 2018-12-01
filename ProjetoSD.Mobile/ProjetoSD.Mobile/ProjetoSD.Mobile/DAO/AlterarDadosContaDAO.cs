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
    public class AlterarDadosContaDAO : INavigationFeature
    {
        #region Propriedades
        public string Controller { get { return "Usuario"; }  }
        public string Url { get { return string.Format($"{Host.Url}/{Controller}"); } }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Método utilizado para buscar informações do usuário.
        /// </summary>
        /// <param name="idMedico">Código de busca.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Método utilizado para atualizar dados do usuário.
        /// </summary>
        /// <param name="idMedico">Representa o código do usuário.</param>
        /// <param name="novaProfissao">Representa a nova profissao do usuário.</param>
        /// <returns></returns>
        public async Task AtualizaProfissao(int idMedico, string novaProfissao)
        {
            HttpClient httpClient = new HttpClient();
            string action = "AlterarProfissaoUsuario";
            string parameters = $"idMedico={idMedico}&novaProfissao={novaProfissao}";
            var request = $"{Url}/{action}?{parameters}";
            var response = await httpClient.PostAsync(request, new StringContent(""));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var messageRequestErro = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(messageRequestErro.Message);
            }
        }

        /// <summary>
        /// Método utilizado para atualizar a senha do usuário.
        /// </summary>
        /// <param name="idMedico">Indica o código que receberá a alteração.</param>
        /// <param name="novaSenha">Indica a nova senha.</param>
        /// <returns></returns>
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
        #endregion
    }
}
