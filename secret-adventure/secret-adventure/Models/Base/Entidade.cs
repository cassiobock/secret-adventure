using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models
{
    public abstract class Entidade
    {

        public string Id { get; set; }
        public Point Posicao { get; set; }
        public bool Ativo { get; set; }
        public TipoClasse TipoEntidade { get; set; }

        public Entidade(Point posicao)
        {
            this.Id = Guid.NewGuid().ToString("N").Substring(0, 8);
            this.Posicao = posicao;
            this.Ativo = true;
        }
        public int GetLinha()
        {
            return this.Posicao.X;
        }
        public int GetColuna()
        {
            return this.Posicao.Y;
        }
    }
}
