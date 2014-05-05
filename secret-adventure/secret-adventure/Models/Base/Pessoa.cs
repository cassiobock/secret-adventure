using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using secret_adventure.Models.Other;
using System.Drawing;

namespace secret_adventure.Models
{
    public class Pessoa : Entidade
    {
        public bool Saudavel { get; set; }
        public List<TipoDengue> DenguesContraidas { get; set; }
        public int RodadasDoente { get; set; }

        public Pessoa(Point posicao)
            : base(posicao)
        {
            this.Saudavel = true;
            this.DenguesContraidas = new List<TipoDengue>();
            this.RodadasDoente = 0;
            base.TipoEntidade = TipoClasse.Pessoa;
        }
    }
}