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
        /// Desativa a entidade
        /// </summary>
        public void Morrer()
        {
            this.Entidade.Ativo = false;
        }

    }
}