using ProjetoSD.Mobile.DAO;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class CadastrarUsuarioMedicoBLL
    {
        private CRMConsultDAO CRMConsultDAO;
        private CadastrarUsuarioMedicoDAO CadastrarUsuarioMedicoDAO;        
        private ValidacaoBLL ValidacaoBLL;
        public CadastrarUsuarioMedicoBLL()
        {
            this.CRMConsultDAO = new CRMConsultDAO();
            this.CadastrarUsuarioMedicoDAO = new CadastrarUsuarioMedicoDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }

        public async Task<ConsultaCRMJson> ConsultaUFCRM(UF uF, string crm)
        {
            return await this.CRMConsultDAO.ConsultaUFCRM(uF, crm);
        }
        public async Task CadastraUsuario(string crm, string nome, UF uF, string profissao, string email, string senha, string confirmacaoSenha)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(crm, "CRM");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(nome, "Nome");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(uF.ToString(), "UF");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(profissao, "Profissão");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(email, "Email");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(senha, "Senha");
            VerificaConfirmacaoDaSenha(senha, confirmacaoSenha);
            await this.CadastrarUsuarioMedicoDAO.CadastraUsuarioAsync(crm, nome, uF, profissao, email, senha);           
        }

        private void VerificaConfirmacaoDaSenha(string senha, string confirmacaoSenha)
        {
            if (senha != confirmacaoSenha)
            {
                throw new ArgumentException("A confirmação da sua senha não coincide com sua senha!");
            }
        }
    }
}
