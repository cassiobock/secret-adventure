using Dengue.Models.Outra;
using secret_adventure.Models.Base;
using secret_adventure.Models.Factory;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class AmbienteManager
    {
        private Ambiente Ambiente;

        /// <summary>
        /// Cria um gerenciador de ambientes
        /// </summary>
        /// <param name="ambiente"></param>
        public AmbienteManager(Ambiente ambiente)
        {
            this.Ambiente = ambiente;
        }

        /// <summary>
        /// Retorna uma matriz com as entidades 
        /// </summary>
        /// <returns>Matriz com entidades</returns>
        public Entidade[,] GetMatriz()
        {
            Entidade[,] matriz = new Entidade[this.Ambiente.Linhas, this.Ambiente.Colunas];
            foreach (var entidade in this.Ambiente.Entidades)
            {
                    matriz[entidade.Posicao.X, entidade.Posicao.Y] = entidade;
            }
            return matriz;
        }

        /// <summary>
        /// Adiciona entidades no ambiente
        /// </summary>
        /// <param name="tipoClasse">Tipo de classe que vai ser criada</param>
        /// <param name="qtdEntidades">Quantidade de entidades</param>
        /// <param name="entidadesSendoCriadas">Lista de temporária de objetos sendo adicionados</param>
        public void GeraEntidades(TipoClasse tipoClasse, int qtdEntidades, List<Entidade> entidadesSendoCriadas)
        {
            for (int i = 1; i <= qtdEntidades; i++)
            {
                Point posicao = Util.GeraPosicao(this.Ambiente.Linhas, this.Ambiente.Colunas);
                // Verifica se já existe alguém na posição selecionada
                while (entidadesSendoCriadas.Count(m => m.Posicao == posicao) != 0)
                {
                    posicao = Util.GeraPosicao(this.Ambiente.Linhas, this.Ambiente.Colunas);
                }
                //Adiciona na lista
                entidadesSendoCriadas.Add(EntidadeFactory.CriaTipoPersonagem(tipoClasse, posicao));
            }
        }
    }
}