using ProjetoSD.Mobile.DAO;
using ProjetoSD.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSD.Mobile.BLL
{
    public class CadastrarDoencaBLL
    {
        #region Propriedades
        private int IdMedico;
        private CadastrarDoencaDAO CadastrarDoencaDAO;
        private ValidacaoBLL ValidacaoBLL;
        #endregion

        #region Construtores
        public CadastrarDoencaBLL(int idMedico)
        {
            this.IdMedico = idMedico;
            this.CadastrarDoencaDAO = new CadastrarDoencaDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método utilizado para cadastrar um novo usuário.
        /// </summary>        
        /// <param name="nomeDoenca">Parâmetro utilizado para informar qual é o nome da doença.</param>
        /// <param name="descricao">Parâmetro utilizado para informar qual é a descrição do <paramref name="nomeDoenca"/>.</param>
        /// <param name="profilaxia">Parâmetro utilizado para informar como evitar a doença.</param>
        /// <returns></returns>
        public async Task Adiciona(string nomeDoenca, string descricao, string profilaxia)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(nomeDoenca, "O que é");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(descricao, "Tratamento");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(profilaxia, "Evite");
            await this.CadastrarDoencaDAO.Cadastrar(IdMedico, nomeDoenca, descricao, profilaxia);
        }
        #endregion
    }
}
