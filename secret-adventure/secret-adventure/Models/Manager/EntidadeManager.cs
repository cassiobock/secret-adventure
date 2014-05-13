using Dengue.Models.Outra;
using secret_adventure.Models.Etc;
using secret_adventure.Models.Factory;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class EntidadeManager : IManager
    {
        private Entidade Entidade;

        /// <summary>
        /// Cria um gerenciador de Entidades
        /// </summary>
        /// <param name="entidade">Entidade que será gerenciada</param>
        public EntidadeManager(Entidade entidade)
        {
            this.Entidade = entidade;
        }

        /// <summary>
        /// Move a entidade para uma nova posição
        /// </summary>
        /// <param name="novaPosicao">Posição para onde a entidade será movida</param>
        public void Mover(Point novaPosicao)
        {
            this.Entidade.Posicao = novaPosicao;
        }
        
        /// <summary>
        /// Executa a ação desejada pela entidade
        /// </summary>
        public void Agir()
        {
            IManager manager = ManagerFactory.GetFactory(this.Entidade);
            manager.Agir();
        }

        /// <summary>
        /// Desativa a entidade
        /// </summary>
        public void Morrer()
        {
            this.Entidade.Ativo = false;
        }

        /// <summary>
        /// Aproxima ou distancia uma entidade de outra
        /// </summary>
        /// <param name="entidade">Entidade alvo</param>
        /// <param name="aproximar">Deve se aproximar ou não</param>
        /// <returns></returns>
        public bool MoverPara(Entidade entidade, bool aproximar = true)
        {
            Direcao direcaoPersonagem = Util.GetDirecao(this.Entidade.Posicao, entidade.Posicao);
            List<Direcao> listaDirecoes = aproximar == true ? Util.GetDirecoesProximas(direcaoPersonagem) : Util.GetDirecoesProximas(direcaoPersonagem, false);
            AmbienteManager manager = new AmbienteManager(Singleton.GetInstance());
            List<Point> ondeIr = manager.GetPosicoesProximasVazias(this.Entidade);
            foreach (var direcao in listaDirecoes)
            {
                foreach (var casa in ondeIr)
                {
                    Direcao direcaoCasa = Util.GetDirecao(this.Entidade.Posicao, casa);
                    if (direcaoCasa == direcao)
                    {
                        this.Mover(casa);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica onde a entidade pode ir e o movimenta para a posição desejada
        /// </summary>
        /// <param name="ondeIr">Matriz de Points com as posições em que a entidade pode se movimentar</param>
        public void Vagar(List<Point> ondeIr)
        {
            AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
            if (ondeIr.Count != 0)
            {
                // Pega posição aleatória
                int posicao = Util.GetRandom(ondeIr.Count);
                // Altera a posição desta entidade para o Point aleatório
                this.Entidade.Posicao = ondeIr[posicao];
            }
        }

    }
}