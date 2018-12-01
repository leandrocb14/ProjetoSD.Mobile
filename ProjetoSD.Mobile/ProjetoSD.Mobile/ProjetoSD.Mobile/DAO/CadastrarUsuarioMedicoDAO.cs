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
    public class CadastrarUsuarioMedicoDAO : INavigationFeature
    {
        #region Propriedades
        public string Controller { get { return "Usuario"; } }
        public string Url { get { return string.Format($"{Host.Url}/{Controller}"); } }        
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método utilizado para cadastrar um novo usuário.
        /// </summary>
        /// <param name="crm">Representa o código do profissional de saúde</param>
        /// <param name="nome">Representa o nome do profissional.</param>
        /// <param name="uF">Representa a unidade federativa do profissional.</param>
        /// <param name="profissao">Representa a profissão do profissional.</param>
        /// <param name="email">Represnta o email do profissional.</param>
        /// <param name="senha">Representa a senha do profissional</param>
        /// <returns></returns>
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
