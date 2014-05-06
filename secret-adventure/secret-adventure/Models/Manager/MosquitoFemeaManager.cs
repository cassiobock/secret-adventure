using secret_adventure.Models.Base;
using secret_adventure.Models.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class MosquitoFemeaManager : IManager, IMosquitoManager
    {
        private MosquitoFemea MosquitoFemea;

        /// <summary>
        /// Inicia um novo gerenciador de mosquito fêmea
        /// </summary>
        /// <param name="mosquitoFemea"></param>
        public MosquitoFemeaManager(MosquitoFemea mosquitoFemea)
        {
            this.MosquitoFemea = mosquitoFemea;
        }

        public void Agir()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move o mosquito fêmea para outra posicação
        /// </summary>
        /// <param name="novaPosicao">Nova posição</param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.MosquitoFemea).Mover(novaPosicao);
        }

        /// <summary>
        /// Desativa o mosquito fêmea
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.MosquitoFemea).Morrer();
        }

        public void Envelhecer()
        {
            throw new NotImplementedException();
        }

        public bool Fugir(Agente agente)
        {
            throw new NotImplementedException();
        }

        public bool Perseguir(Entidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}