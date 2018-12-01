using ProjetoSD.Mobile.DAO;
using ProjetoSD.Mobile.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class LoginBLL
    {
        #region Propriedades
        private LoginDAO LoginDAO;
        private ValidacaoBLL ValidacaoBLL;
        #endregion

        #region Construtores
        public LoginBLL()
        {
            this.LoginDAO = new LoginDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método utilizado para verificar a existencia do usuário.
        /// </summary>
        /// <param name="email">Utilizado para identificar o email utilizado pelo profissional.</param>
        /// <param name="senha">Utilizado para identificar a chave utilizado pelo <paramref name="email"/> do profissional.</param>
        /// <returns></returns>
        public async Task<int> VerificaAutenticacao(string email, string senha)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(email, "Email");
            this.ValidacaoBLL.VerificaSeEhEmail(email);
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(senha, "Senha");
            return await this.LoginDAO.VerificaAutenticacao(email, senha);          
        }
        #endregion
    }
}
