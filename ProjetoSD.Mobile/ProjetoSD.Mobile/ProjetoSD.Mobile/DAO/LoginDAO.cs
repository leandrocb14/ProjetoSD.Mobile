using Newtonsoft.Json;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.DAO
{
    public class LoginDAO : INavigationFeature
    {
        #region Propriedades
        public string Controller { get { return "Usuario"; } }
        public string Url { get { return string.Format($"{Host.Url}/{Controller}"); } }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Utilizado para verificar a existência da combinação entre o email e a senha dentro da base de dados.
        /// </summary>
        /// <exception cref="ArgumentException">Exception lançada quando não existir nenhuma combinação com os parâmetros passados (<paramref name="email"/> e <paramref name="senha"/>)</exception>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public async Task<int> VerificaAutenticacao(string email, string senha)
        {
            HttpClient cliente = new HttpClient();
            var action = "ValidaLogin";
            var parameters = $"email={email}&senha={senha}";
            var request = string.Format($"{Url}/{action}?{parameters}");                        
            var response = await cliente.PostAsync(request, new StringContent(""));            
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var ErrorMessageRequest = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new UsuarioNotFoundException(ErrorMessageRequest.Message);
            }
            var SucessMessageRequest = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
            return SucessMessageRequest;
        }
        #endregion
    }
}
