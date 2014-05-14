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
        /// Retorna todas entidades existentes
        /// </summary>
        /// <returns></returns>
        public List<Entidade> GetListaEntidades()
        {
            return this.Ambiente.Entidades;
        }

        /// <summary>
        /// Retorna entidades que serão adicionadas na fila
        /// </summary>
        /// <returns></returns>
        public List<Entidade> GetListaEntidadesNaFilaParaAdicionar()
        {
            return this.Ambiente.EntidadesQueSeraoAdicionadas;
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

        /// <summary>
        /// Retorna lista de entidades próximas
        /// </summary>
        /// <param name="entidade">Entidade a partir de onde deve-se verificar</param>
        /// <param name="nivel">Nível de resultado</param>
        /// <returns></returns>
        public List<Entidade> GetEntidadesProximas(Entidade entidade, int nivel)
        {
            List<Entidade> entidadesProximas = new List<Entidade>();
            Entidade[,] matriz = this.GetMatriz();
            // Se que 0, define zero como limite, caso contrário pega o valor e subtrai o número de níveis desejados
            int limiteSuperior = entidade.GetLinha() - nivel < 0 ? 0 : entidade.GetLinha() - nivel;
            int limiteEsquerda = entidade.GetColuna() - nivel < 0 ? 0 : entidade.GetColuna() - nivel;
            // Se maior que o tamanho da matriz, define o valor de casas na matriz como limite, caso contrário soma o valor do nível desejado
            int limiteInferior = entidade.GetLinha() + nivel >= matriz.GetLength(0) ? matriz.GetLength(0) - 1 : entidade.GetLinha() + nivel;
            int limiteDireita = entidade.GetColuna() + nivel >= matriz.GetLength(1) ? matriz.GetLength(1) - 1 : entidade.GetColuna() + nivel;
            // Verifica da esquerda para direita e de cima para baixo quais objetos se encontram no nível desejado
            for (int coluna = limiteEsquerda; coluna <= limiteDireita; coluna++)
            {
                for (int linha = limiteSuperior; linha <= limiteInferior; linha++)
                {
                    //Verifica se o valor é nulo e se não é o próprio personagem
                    if (matriz[linha, coluna] != null && matriz[linha, coluna].Id != entidade.Id && matriz[linha, coluna].Ativo == true)
                    {
                        //Adiciona na lista de objetos daquele nível
                        entidadesProximas.Add(matriz[linha, coluna]);
                    }
                }
            }
            return entidadesProximas;
        }

        /// <summary>
        /// Retorna as posições para onde a entidade pode se dirigir
        /// </summary>
        /// <param name="entidade">Entidade a partir de onde deve-se verificar</param>
        /// <returns></returns>
        public List<Point> GetPosicoesProximasVazias(Entidade entidade)
        {
            Entidade[,] matriz = this.GetMatriz();
            // Se que 0, define zero como limite, caso contrário pega o valor e subtrai o número de níveis desejados
            int limiteEsquerda = entidade.GetLinha() - 1 < 0 ? 0 : entidade.GetLinha() - 1;
            int limiteSuperior = entidade.GetColuna() - 1 < 0 ? 0 : entidade.GetColuna() - 1;
            // Se maior que o tamanho da matriz, define o valor de casas na matriz como limite, caso contrário soma o valor do nível desejado
            int limiteDireita = entidade.GetLinha() + 1 > matriz.GetLength(0) - 1 ? matriz.GetLength(0) : entidade.GetLinha() + 2;
            int limiteInferior = entidade.GetColuna() + 1 > matriz.GetLength(1) - 1 ? matriz.GetLength(1) : entidade.GetColuna() + 2;
            // Valor real do tamanho
            int linhasTotais = limiteDireita - limiteEsquerda;
            int colunasTotais = limiteInferior - limiteSuperior;
            List<Point> ondeIr = new List<Point>();
            for (int linha = limiteEsquerda; linha < limiteDireita; linha++)
            {
                for (int coluna = limiteSuperior; coluna < limiteInferior; coluna++)
                {
                    if (matriz[linha, coluna] == null)
                    {
                        ondeIr.Add(new Point(linha, coluna));
                    }
                }
            }
            return ondeIr;
        }

        /// <summary>
        /// Adiciona entidades na fila para serem adicionados
        /// </summary>
        /// <param name="entidadesParaAdicionar">Entidades que serão adicionadas à fila</param>
        public void AdicionarEntidades(List<Entidade> entidadesParaAdicionar)
        {
            foreach (var entidade in entidadesParaAdicionar)
            {
                this.Ambiente.EntidadesQueSeraoAdicionadas.Add(entidade);
            }
        }
        /// <summary>
        /// Remove uma entidade da lista
        /// </summary>
        /// <param name="entidade">Entidade que será removida</param>
        private void RemoveEntidade(Entidade entidade)
        {
            this.GetListaEntidades().Remove(entidade);
        }

        /// <summary>
        /// Remove entidades desativadas e adiciona novas enidades na fila
        /// </summary>
        public void Processar()
        {
            List<Entidade> itensRemovidos = this.GetListaEntidades().Where(m => m.Ativo == false).ToList();
            foreach (var entidade in itensRemovidos)
            {
                this.RemoveEntidade(entidade);
            }
            if (this.GetListaEntidadesNaFilaParaAdicionar().Count != 0)
            {
                foreach (var entidade in this.GetListaEntidadesNaFilaParaAdicionar())
                {
                    this.GetListaEntidades().Add(entidade);
                }
                this.Ambiente.EntidadesQueSeraoAdicionadas.Clear();
            }
        }
    }
}