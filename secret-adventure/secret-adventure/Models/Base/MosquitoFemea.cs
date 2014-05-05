using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Base
{
    public class MosquitoFemea : Mosquito
    {
        public bool ComFome { get; set; }
        public Pessoa Alvo { get; set; }

        public MosquitoFemea(Point posicao)
            : base(posicao)
        {
            base.TipoEntidade = TipoClasse.MosquitoFemea;
            this.ComFome = true;
            this.Sexo = Sexo.Femea;
        }
        public MosquitoFemea(Point posicao, Estagio estagio, TipoDengue tipoDengue)
            : base(posicao)
        {
            base.Estagio = estagio;
            base.TipoEntidade = TipoClasse.MosquitoFemea;
            base.TipoDengue = tipoDengue;
            this.ComFome = true;
            this.Sexo = Sexo.Femea;
        }
    }
}
