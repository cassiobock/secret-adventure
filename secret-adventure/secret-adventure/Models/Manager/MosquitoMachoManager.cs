using secret_adventure.Models.Base;
using secret_adventure.Models.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class MosquitoMachoManager : IManager, IMosquitoManager
    {
        private MosquitoMacho MosquitoMacho;

        public MosquitoMachoManager(MosquitoMacho mosquitoMacho)
        {
            this.MosquitoMacho = mosquitoMacho;
        }

        public void Agir()
        {
            throw new NotImplementedException();
        }
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.MosquitoMacho).Mover(novaPosicao);
        }

        public void Morrer()
        {
            new EntidadeManager(this.MosquitoMacho).Morrer();
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