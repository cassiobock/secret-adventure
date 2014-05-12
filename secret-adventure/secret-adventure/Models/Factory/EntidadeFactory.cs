using Dengue.Models.Outra;
using secret_adventure.Models.Base;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Factory
{
    public class EntidadeFactory
    {
        public static Entidade CriaTipoPersonagem(TipoClasse tipo, Point posicao)
        {
            Entidade entidade = null;
            switch (tipo)
            {
                case TipoClasse.Pessoa: entidade = new Pessoa(posicao);
                    break;
                case TipoClasse.Mosquito:
                    //Gera um sexo aleatório: masculino ou feminino
                    Sexo sexo = Util.GetRandom(2) % 2 == 0 ? Sexo.Macho : Sexo.Femea;
                    //Cria um personagem de acordo com o sexo
                    entidade = sexo == Sexo.Macho ? (Entidade)new MosquitoMacho(posicao) : (Entidade)new MosquitoFemea(posicao);
                    break;
                case TipoClasse.Agente: entidade = new Agente(posicao);
                    break;
            }
            return entidade;
        }
    }
}