using ProjetoSD.Mobile.DAO;
using ProjetoSD.Mobile.Exceptions;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class AlterarDadosContaBLL
    {
        private ValidacaoBLL ValidacaoBLL;
        private AlterarDadosContaDAO AlterarDadosContaDAO;
        private int IdMedico;

        public AlterarDadosContaBLL(int idMedico)
        {
            this.IdMedico = idMedico;
            this.ValidacaoBLL = new ValidacaoBLL();
            this.AlterarDadosContaDAO = new AlterarDadosContaDAO();
        }

        public Task<MedicoJson> BuscaInformacoesUsuario()
        {
            return this.AlterarDadosContaDAO.BuscaInformacoesUsuario(IdMedico);
        }

        public async Task AlterarDadosUsuario(string profissao, string novaSenha, string cNovaSenha)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(profissao, "profissão");
            bool NovaSenhaOuCNovaSenhaPreenchidos = !string.IsNullOrEmpty(novaSenha) || !string.IsNullOrEmpty(cNovaSenha);
            if (NovaSenhaOuCNovaSenhaPreenchidos)
            {
                if (string.IsNullOrEmpty(novaSenha) && (!string.IsNullOrEmpty(cNovaSenha)))
                {
                    throw new ConfirmacaoSenhaSemReferenciaException("Não é possível confirmar uma senha sem a sua referência!");
                }
                if ((!string.IsNullOrEmpty(novaSenha)) && string.IsNullOrEmpty(cNovaSenha))
                {
                    throw new SenhaSemConfirmacaoException("É preciso confirmar a sua senha!");
                }
                this.ValidacaoBLL.VerificaConfirmacaoDaSenha(novaSenha, cNovaSenha);
                if (novaSenha != cNovaSenha)
                {
                    throw new ConfirmationPasswordDifferentException("A confirmação da senha não coincide com sua nova senha digitada!");
                }
                await this.AlterarDadosContaDAO.AtualizaProfissao(IdMedico, profissao);
                await this.AlterarDadosContaDAO.AtualizaSenha(IdMedico, novaSenha);
            }
            else
            {
                await this.AlterarDadosContaDAO.AtualizaProfissao(IdMedico, profissao);
            }

            

        }
    }
}
