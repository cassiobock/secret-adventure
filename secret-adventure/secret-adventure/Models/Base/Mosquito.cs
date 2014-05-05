using Dengue.Models.Outra;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Base
{
    public abstract class Mosquito : Entidade
    {
        public Estagio Estagio { get; set; }
        public Sexo Sexo { get; set; }
        public TipoDengue TipoDengue { get; set; }
        public int TempoDeVida { get; set; }

        public Mosquito(Point posicao)
            : base(posicao)
        {
            this.Estagio = (Estagio)Enum.GetValues(typeof(Estagio)).GetValue(Util.GetRandom(Enum.GetValues(typeof(Estagio)).Length));
            this.TipoDengue = (TipoDengue)Enum.GetValues(typeof(TipoDengue)).GetValue(Util.GetRandom(Enum.GetValues(typeof(TipoDengue)).Length));
            this.TempoDeVida = 20;
        }
    }
}
