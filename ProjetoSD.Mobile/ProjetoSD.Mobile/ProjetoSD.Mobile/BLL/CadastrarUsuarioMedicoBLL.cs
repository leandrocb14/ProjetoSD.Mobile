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
        public async Task<ConsultaCRMJson> ConsultaUFCRM(UF uF, string crm)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(crm, "CRM");
            return await this.CRMConsultDAO.ConsultaUFCRM(uF, crm);
        }
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
        #endregion
    }
}
