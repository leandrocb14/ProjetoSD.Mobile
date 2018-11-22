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
        /// <exception cref="ArgumentException">Exception lançada quando o valor do parâmetro for nulo ou vazio./></exception>
        /// <param name="valorParametro">Representa o valor da variável.</param>
        /// <param name="nomeParametro">Representa o nome da variável.</param>
        public void VerificaSeParametroEhNuloOuVazio(string valorParametro, string nomeParametro)
        {
            if (string.IsNullOrEmpty(valorParametro))
            {
                throw new ArgumentException($"O Campo {nomeParametro} não Pode Estar em Branco!");
            }
        }        
    }
}
