using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Other
{
    public enum Estagio
    {
        Ovo = 3,
        Pupa = 2,
        Larva = 1,
        Adulto = 0
    }

    public enum Sexo
    {
        Macho,
        Femea
    }

    public enum TipoDengue
    {
        InfeccaoInaparente,
        Classica,
        Hemorragica,
        Choque,
        Nenhuma
    }
    public enum TipoClasse
    {
        Pessoa,
        Mosquito,
        MosquitoFemea,
        MosquitoMacho,
        Agente
    }
    public enum Direcao
    {
        Esquerda,
        EsquerdaCima,
        Cima,
        DireitaCima,
        Direita,
        DireitaBaixo,
        Baixo,
        EsquerdaBaixo
    }
}