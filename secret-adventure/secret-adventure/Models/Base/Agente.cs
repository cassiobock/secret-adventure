using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Base
{
    public class Agente : Entidade
    {
        public int MosquitosMortos { get; set; }
        public Mosquito Alvo { get; set; }
        public Agente(Point posicao)
            : base(posicao)
        {
            base.TipoEntidade = TipoClasse.Agente;
        }
    }
}