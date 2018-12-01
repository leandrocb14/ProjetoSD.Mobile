using ProjetoSD.Mobile.DAO;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class CadastrarUsuarioMedicoBLL
    {
        #region Propriedades
        private CRMConsultDAO CRMConsultDAO;
        private CadastrarUsuarioMedicoDAO CadastrarUsuarioMedicoDAO;
        private ValidacaoBLL ValidacaoBLL;
        #endregion

        #region Construtores
        public CadastrarUsuarioMedicoBLL()
        {
            this.CRMConsultDAO = new CRMConsultDAO();
            this.CadastrarUsuarioMedicoDAO = new CadastrarUsuarioMedicoDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }
        #endregion

        #region Método Público
        /// <summary>
        /// Método utilizado para cadastrar um novo usuário.
        /// </summary>
        /// <param name="crm">Parâmetro utilizado para representar o número do profissional de saúde.</param>
        /// <param name="nome">Parâmetro utilizado para representar o nome do profissional</param>
        /// <param name="uF">Parâmetro utilizado para representar a unidade federativa do profissional.</param>
        /// <param name="profissao">Parâmetro utilizado para representar a profissão do profissional.</param>
        /// <param name="email">Parâmetro utilizado para representar o email do profissional.</param>
        /// <param name="senha">Parâmetro utilizado para representar a senha de autenticação desse usuário.</param>
        /// <param name="confirmacaoSenha">Parâmetro utilizado para confirmar a senha digita em <paramref name="senha"/>.</param>
        /// <returns></returns>
        public async Task CadastraUsuario(string crm, string nome, UF uF, string profissao, string email, string senha, string confirmacaoSenha)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(crm, "CRM");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(nome, "Nome");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(uF.ToString(), "UF");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(profissao, "Profissão");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(email, "Email");
            this.ValidacaoBLL.VerificaSeEhEmail(email);
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(senha, "Senha");
            this.ValidacaoBLL.VerificaConfirmacaoDaSenha(senha, confirmacaoSenha);
            await this.CadastrarUsuarioMedicoDAO.CadastraUsuario(crm, nome, uF, profissao, email, senha);
        }
        /// <summary>
        /// Método utilizado para consultar informações mais detalhadas do profissional de saúde.
        /// </summary>
        /// <param name="uF">Parâmetro usado para indicar a unidade federativa do profissional.</param>
        /// <param name="crm">Parâmetro usado para indicar o número de identificação do profissional.</param>
        /// <returns></returns>
        public async Task<ConsultaCRMJson> ConsultaUFCRM(UF uF, string crm)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(crm, "CRM");
            return await this.CRMConsultDAO.ConsultaUFCRM(uF, crm);
        }        
        #endregion
    }
}
