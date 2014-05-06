using secret_adventure.Models.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class AgenteManager : IManager
    {
        private Agente Agente;

        /// <summary>
        /// Cria um novo gerenciador de agente
        /// </summary>
        /// <param name="agente"></param>
        public AgenteManager(Agente agente)
        {
            this.Agente = agente;
        }

        /// <summary>
        /// Move o agente para uma nova posição
        /// </summary>
        /// <param name="novaPosicao">Nova posição</param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.Agente).Mover(novaPosicao);
        }

        /// <summary>
        /// Desativa o agente
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.Agente).Morrer();
        }

        /// <summary>
        /// Mata um mosquito
        /// </summary>
        /// <param name="mosquito"></param>
        public void MatarMosquito(Mosquito mosquito)
        {
            new EntidadeManager(mosquito).Morrer();
        }
    }
}