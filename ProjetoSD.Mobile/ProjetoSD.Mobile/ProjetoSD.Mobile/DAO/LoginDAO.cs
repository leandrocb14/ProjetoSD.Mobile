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
    public class LoginDAO
    {
        private static string Controller = "Usuario";
        private string Uri = string.Format($"{Host.Url}/{Controller}");

        /// <summary>
        /// Utilizado para verificar a existência da combinação entre o email e a senha dentro da base de dados.
        /// </summary>
        /// <exception cref="ArgumentException">Exception lançada quando não existir nenhuma combinação com os parâmetros passados (<paramref name="email"/> e <paramref name="senha"/>)</exception>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public async Task VerificaAutenticacao(string email, string senha)
        {
            HttpClient cliente = new HttpClient();
            var action = "ValidaLogin";
            var parameters = $"email={email}&senha={senha}";
            var request = string.Format($"{Uri}/{action}?{parameters}");                        
            var response = await cliente.PostAsync(request, new StringContent(""));            
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var messageRequestNotFound = JsonConvert.DeserializeObject<ExceptionJson>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(messageRequestNotFound.Message);
            }
        }
    }
}
