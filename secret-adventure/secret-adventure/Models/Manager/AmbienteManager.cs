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
        /// <returns></returns>
        public Entidade[,] GetMatriz()
        {
            Entidade[,] matriz = new Entidade[this.Ambiente.Linhas, this.Ambiente.Colunas];
            foreach (var entidade in this.Ambiente.Entidades)
            {
                if (matriz[entidade.Posicao.X, entidade.Posicao.Y] != null)
                {
                    matriz[entidade.Posicao.X, entidade.Posicao.Y] = entidade;
                }
                else
                {
                    throw new Exception("Existem entidades com posições duplicadas.");
                }
            }
            return matriz;
        }

        internal void GeraEntidades(TipoClasse tipoClasse, int qtdPersonagens, List<Entidade> entidadesSendoCriadas)
        {
            for (int i = 1; i <= qtdPersonagens; i++)
            {
                Point posicao = Util.GeraPosicao(this.Ambiente.Linhas, this.Ambiente.Colunas);
                // Verifica se já existe alguém na posição selecionada
                int entidades = this.Ambiente.Entidades.Count;
                while (this.Ambiente.Entidades.Count(m => m.Posicao == posicao) == 0)
                {
                    // Gera uma nova posição
                    if (entidades != 0)
                    {
                        posicao = Util.GeraPosicao(this.Ambiente.Linhas, this.Ambiente.Colunas);
                        entidades--;
                    }
                    else
                    {
                        throw new Exception("Sem espaços disponíveis.");
                    }
                }
                //Adiciona na lista
                entidadesSendoCriadas.Add(EntidadeFactory.CriaTipoPersonagem(tipoClasse, posicao));
            }
        }
    }
}