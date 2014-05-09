using Dengue.Models.Outra;
using secret_adventure.Models.Manager;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Base
{
    public class Ambiente
    {
        public List<Entidade> Entidades = new List<Entidade>();
        public int Linhas;
        public int Colunas;
        public List<Entidade> PersonagensQueSeraoAdicionados = new List<Entidade>();

        public Ambiente(int linhas, int colunas, int qtdMosquitos, int qtdPessoas, int qtdAgentes)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            List<Entidade> entidadesSendoCriadas = new List<Entidade>();
            new AmbienteManager(this).GeraEntidades(TipoClasse.Agente, qtdAgentes, entidadesSendoCriadas);
            new AmbienteManager(this).GeraEntidades(TipoClasse.Mosquito, qtdMosquitos, entidadesSendoCriadas);
            new AmbienteManager(this).GeraEntidades(TipoClasse.Pessoa, qtdPessoas, entidadesSendoCriadas);
            this.Entidades = Util.Shuffle<Entidade>(entidadesSendoCriadas);
        }
    }
}