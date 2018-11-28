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

        private CadastrarDoencaDAO CadastrarDoencaDAO;
        private ValidacaoBLL ValidacaoBLL;

        public CadastrarDoencaBLL()
        {
            this.CadastrarDoencaDAO = new CadastrarDoencaDAO();
            this.ValidacaoBLL = new ValidacaoBLL();
        }

        public async Task Adiciona(int idMedico, string nomeDoenca, string descricao, string profilaxia)
        {
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(nomeDoenca, "O que é");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(descricao, "Tratamento");
            this.ValidacaoBLL.VerificaSeParametroEhNuloOuVazio(profilaxia, "Evite");
            await this.CadastrarDoencaDAO.Cadastrar(idMedico, nomeDoenca, descricao, profilaxia);
        }
    }
}
