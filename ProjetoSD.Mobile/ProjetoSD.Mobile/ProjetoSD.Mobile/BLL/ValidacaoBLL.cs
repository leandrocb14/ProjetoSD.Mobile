using ProjetoSD.Mobile.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSD.Mobile.BLL
{
    public class ValidacaoBLL
    {
        /// <summary>
        /// Método utilizado para verificar se o valor passado em <paramref name="valorParametro"/> é nulo ou vazio.
        /// </summary>
        /// <exception cref="CampoNullOrEmptyException">Exception lançada quando o valor do parâmetro for nulo ou vazio./></exception>
        /// <param name="valorParametro">Representa o valor da variável.</param>
        /// <param name="nomeParametro">Representa o nome da variável.</param>
        public void VerificaSeParametroEhNuloOuVazio(string valorParametro, string nomeParametro)
        {
            if (string.IsNullOrEmpty(valorParametro))
            {
                throw new CampoNullOrEmptyException($"O campo {nomeParametro} não pode estar em branco!");
            }
        }

        public void VerificaSeEhEmail(string email)
        {
            if (!(email.Contains("@") && email.Contains(".com")))
            {
                throw new EmailInvalidoException("O Email passado é inválido!");
            }
        }

        public void VerificaConfirmacaoDaSenha(string senha, string confirmacaoSenha)
        {
            if (senha != confirmacaoSenha)
            {
                throw new ConfirmationPasswordDifferentException("A confirmação da sua senha não coincide com sua senha!");
            }
        }
    }
}
