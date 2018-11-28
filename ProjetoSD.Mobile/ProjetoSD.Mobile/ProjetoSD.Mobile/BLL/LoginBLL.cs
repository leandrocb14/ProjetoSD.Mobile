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
