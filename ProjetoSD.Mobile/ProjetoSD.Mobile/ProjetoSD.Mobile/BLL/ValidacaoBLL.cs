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

        /// <summary>
        /// Método utilizado para verificar se o email está realmente dentro do padrão de um email.
        /// </summary>
        /// <param name="email">Parâmetro utilizado para representar o email do usuário.</param>
        public void VerificaSeEhEmail(string email)
        {
            if (!(email.Contains("@") && email.Contains(".com")))
            {
                throw new EmailInvalidoException("O Email passado é inválido!");
            }
        }

        /// <summary>
        /// Método utilizado para realizar a confirmação da senha.
        /// </summary>
        /// <param name="senha">Representa a senha digitada.</param>
        /// <param name="confirmacaoSenha">Representa a confirmação da senha baseado no <paramref name="senha"/>.</param>
        public void VerificaConfirmacaoDaSenha(string senha, string confirmacaoSenha)
        {
            if (senha != confirmacaoSenha)
            {
                throw new ConfirmationPasswordDifferentException("A confirmação da sua senha não coincide com sua senha!");
            }
        }
    }
}
