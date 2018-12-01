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
        #region Propriedades
        private ValidacaoBLL ValidacaoBLL;
        private AlterarDadosContaDAO AlterarDadosContaDAO;
        private int IdMedico;
        #endregion

        #region Construtores
        public AlterarDadosContaBLL(int idMedico)
        {
            this.IdMedico = idMedico;
            this.ValidacaoBLL = new ValidacaoBLL();
            this.AlterarDadosContaDAO = new AlterarDadosContaDAO();
        }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Método utilizado para alterar os dados do usuário.
        /// </summary>
        /// <exception cref="ConfirmacaoSenhaSemReferenciaException">Exception lançada quando <paramref name="cNovaSenha"/> não é igual a <paramref name="novaSenha"/>.</exception>
        /// <exception cref="SenhaSemConfirmacaoException">Exception lançada quando é preenchido <paramref name="novaSenha"/> porém não foi preenchido <paramref name="cNovaSenha"/>.</exception>
        /// <exception cref="ConfirmationPasswordDifferentException">Exception lançada quando a <paramref name="cNovaSenha"/> não é igual a <paramref name="novaSenha"/>.</exception>
        /// <param name="profissao">Parâmetro utilizado para sobrescrever a antiga profissão.</param>
        /// <param name="novaSenha">Parâmetro utilizado para sobrescrever a antiga senha.</param>
        /// <param name="cNovaSenha">Parâmetro utilizado para confirmar se é igual a <paramref name="novaSenha"/></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método utilizado para buscar informações do usuário
        /// </summary>
        /// <returns>Retorna informações do usuário logado</returns>
        public Task<MedicoJson> BuscaInformacoesUsuario()
        {
            return this.AlterarDadosContaDAO.BuscaInformacoesUsuario(IdMedico);
        }        
        #endregion
    }
}
