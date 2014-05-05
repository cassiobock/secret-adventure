using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Dengue.Models.Outra
{
    public class Util
    {
        #region Variaveis
        private static Random Random = new Random();
        private static readonly List<Direcao> DirecoesEsquerda = new List<Direcao>() { Direcao.Esquerda, Direcao.EsquerdaBaixo, Direcao.EsquerdaCima, Direcao.Baixo, Direcao.Cima, Direcao.DireitaBaixo, Direcao.DireitaCima, Direcao.Direita };
        private static readonly List<Direcao> DirecoesDiagonalEsquerdaCima = new List<Direcao>() { Direcao.EsquerdaCima, Direcao.Esquerda, Direcao.Cima, Direcao.EsquerdaBaixo, Direcao.DireitaCima, Direcao.Baixo, Direcao.Direita, Direcao.DireitaBaixo };
        private static readonly List<Direcao> DirecoesCima = new List<Direcao>() { Direcao.Cima, Direcao.EsquerdaCima, Direcao.DireitaCima, Direcao.Esquerda, Direcao.Direita, Direcao.EsquerdaBaixo, Direcao.DireitaBaixo, Direcao.Baixo };
        private static readonly List<Direcao> DirecoesDiagonalDireitaCima = new List<Direcao>() { Direcao.DireitaCima, Direcao.Cima, Direcao.Direita, Direcao.EsquerdaCima, Direcao.DireitaBaixo, Direcao.Esquerda, Direcao.Baixo, Direcao.EsquerdaBaixo };
        private static readonly List<Direcao> DirecoesDireita = new List<Direcao>() { Direcao.Direita, Direcao.DireitaCima, Direcao.DireitaBaixo, Direcao.Cima, Direcao.Baixo, Direcao.EsquerdaCima, Direcao.EsquerdaBaixo, Direcao.Esquerda };
        private static readonly List<Direcao> DirecoesDiagonalDireitaBaixo = new List<Direcao>() { Direcao.DireitaBaixo, Direcao.Direita, Direcao.Baixo, Direcao.DireitaCima, Direcao.EsquerdaBaixo, Direcao.Cima, Direcao.Esquerda, Direcao.EsquerdaCima };
        private static readonly List<Direcao> DirecoesBaixo = new List<Direcao> { Direcao.Baixo, Direcao.DireitaBaixo, Direcao.EsquerdaBaixo, Direcao.Direita, Direcao.Esquerda, Direcao.DireitaCima, Direcao.EsquerdaCima, Direcao.Cima };
        private static readonly List<Direcao> DirecoesDiagonalEsquerdaBaixo = new List<Direcao> { Direcao.EsquerdaBaixo, Direcao.Baixo, Direcao.Esquerda, Direcao.DireitaBaixo, Direcao.EsquerdaCima, Direcao.Direita, Direcao.Cima, Direcao.DireitaCima };
        private static readonly List<List<Direcao>> ListaDeDirecoes = new List<List<Direcao>>() 
        { 
            DirecoesEsquerda,
            DirecoesDiagonalEsquerdaCima,
            DirecoesCima,
            DirecoesDiagonalDireitaCima,
            DirecoesDireita,
            DirecoesDiagonalDireitaBaixo,
            DirecoesBaixo,
            DirecoesDiagonalEsquerdaBaixo
        };
        #endregion

        /// <summary>
        /// Gera valores aleatórias para a coluna e a linha dos personagens de 0 até número máximo definido
        /// </summary>
        /// <returns>Point: X = linha e Y = coluna</returns>
        public static Point GeraPosicao(int linha, int coluna)
        {
            int linhaAleatoria = Random.Next(0, linha);
            int colunaAleatoria = Random.Next(0, coluna);
            return new Point(linhaAleatoria, colunaAleatoria);
        }
        /// <summary>
        /// Gera valores aleatórias para a coluna e a linha dos personagens, porém permitindo que sejam definidos os valores
        /// </summary>
        /// <returns>Point: X = linha e Y = coluna</returns>
        public static Point GeraPosicao(int limiteEsquerda, int limiteDireita, int limiteSuperior, int limiteInferior)
        {
            int linhaAleatoria = Random.Next(limiteEsquerda, limiteDireita);
            int colunaAleatoria = Random.Next(limiteSuperior, limiteInferior);
            return new Point(linhaAleatoria, colunaAleatoria);
        }

        /// <summary>
        /// Gera um valor aleatório único
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandom(int maxValue)
        {
            return Random.Next(0, maxValue);
        }

        /// <summary>
        /// Descobre a direção que um objeto se encontra em relação a outro
        /// </summary>
        /// <param name="personagemOrigem">Posição de origem</param>
        /// <param name="personagemDestino">Posição de destino</param>
        /// <returns>Direção do objeto</returns>
        public static Direcao GetDirecao(Point personagemOrigem, Point personagemDestino)
        {
            // X = Linha
            // Y = Coluna
            // Se linha da origem for igual a linha do destino E coluna de origem for maior que do destino
            if (personagemOrigem.X == personagemDestino.X && personagemOrigem.Y > personagemDestino.Y)
            {
                return Direcao.Esquerda;
            }
            // Se linha de origem for maior que do destino E coluna de origem for maior que do destino
            else if (personagemOrigem.X > personagemDestino.X && personagemOrigem.Y > personagemDestino.Y)
            {
                return Direcao.EsquerdaCima;
            }
            // Se linha de origem for maior que do destino E a coluna de origem for igual a do destino
            else if (personagemOrigem.X > personagemDestino.X && personagemOrigem.Y == personagemDestino.Y)
            {
                return Direcao.Cima;
            }
            // Se a linha de origem for maior que linha de destino E coluna de origem for menor que do destino
            else if (personagemOrigem.X > personagemDestino.X && personagemOrigem.Y < personagemDestino.Y)
            {
                return Direcao.DireitaCima;
            }
            // Se linha de origem for igual do destino E coluna de origem for menor que do destino
            else if (personagemOrigem.X == personagemDestino.X && personagemOrigem.Y < personagemDestino.Y)
            {
                return Direcao.Direita;
            }
            // Se linha de origem for menor que do destino E coluna for menor que do destino
            else if (personagemOrigem.X < personagemDestino.X && personagemOrigem.Y < personagemDestino.Y)
            {
                return Direcao.DireitaBaixo;
            }
            // Se linha de origem for maior que do destino E coluna de origem for igual a do destino
            else if (personagemOrigem.X < personagemDestino.X && personagemOrigem.Y == personagemDestino.Y)
            {
                return Direcao.Baixo;
            }
            // Se linha de origem for menor que do destino E coluna de origem for maior que do destino
            else
            {
                return Direcao.EsquerdaBaixo;
            }
        }
        /// <summary>
        /// Retorna uma lista de direções a serem seguidas
        /// </summary>
        /// <param name="direcao">Direção que se deseja descobrir as posiçõesp próximas</param>
        /// <returns>Lista de Direcoes próximas à solicitada</returns>
        public static List<Direcao> GetDirecoesProximas(Direcao direcao, bool comecoParaFim = true)
        {
            List<Direcao> direcaoDesejada = null;
            //Passa na lista de listas
            foreach (var listaDirecao in ListaDeDirecoes)
            {
                // Quero ir para lá
                if (comecoParaFim == true)
                {
                    //Compara se o primeiro valor da lista, que é o principal, é igual a direção desejada
                    if (listaDirecao.First() == direcao)
                    {
                        // Atribui a direção para o valor de retorno
                        direcaoDesejada = listaDirecao;
                    }
                }
                // Quero ficar longe de lá
                else
                {
                    if (listaDirecao.Last() == direcao)
                    {
                        direcaoDesejada = listaDirecao;
                    }
                }
            }
            return direcaoDesejada; // Retorna a lista
        }
        /// <summary>
        /// Embaralha uma lista
        /// </summary>
        /// <typeparam name="T">Tipo de lista</typeparam>
        /// <param name="lista">Lista que será embaralhada</param>
        /// <returns>Lista reordenada de forma aleatória.</returns>
        public static List<T> Shuffle<T>(List<T> lista)
        {
            for (int i = lista.Count; i > 0; i--)
            {
                // Pega um elemento aleatório para trocar.
                int j = Random.Next(i);
                // Troca.
                T tmp = lista[j];
                lista[j] = lista[i - 1];
                lista[i - 1] = tmp;
            }
            return lista;
        }
    }
}
