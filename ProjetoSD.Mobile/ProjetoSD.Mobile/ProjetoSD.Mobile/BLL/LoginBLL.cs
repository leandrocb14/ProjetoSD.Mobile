using ProjetoSD.Mobile.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class LoginBLL
    {
        private LoginDAO LoginDAO;
        private ValidacaoBLL ValidacaoBLL;

        public LoginBLL()
        {
            this.LoginDAO = new LoginDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }

        public async Task VerificaAutenticacao(string email, string senha)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(email, "Email");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(senha, "Senha");
            await this.LoginDAO.VerificaAutenticacao(email, senha);           
            
        }
    }
}
