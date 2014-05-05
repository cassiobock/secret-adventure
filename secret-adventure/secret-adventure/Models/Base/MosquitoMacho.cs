using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Base
{
    public class MosquitoMacho : Mosquito
    {
        public MosquitoMacho(Point posicao)
            : base(posicao)
        {
            base.TipoEntidade = TipoClasse.MosquitoMacho;
            this.Sexo = Sexo.Macho;
        }

        public MosquitoMacho(Point posicao, Estagio estagio, TipoDengue tipoDengue)
            : base(posicao)
        {
            base.TipoEntidade = TipoClasse.MosquitoMacho;
            base.Estagio = estagio;
            base.TipoDengue = tipoDengue;
            this.Sexo = Sexo.Macho;
        }
    }
}
