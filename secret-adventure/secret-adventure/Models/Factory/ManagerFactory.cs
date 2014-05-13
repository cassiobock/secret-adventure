using secret_adventure.Models.Base;
using secret_adventure.Models.Manager;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Factory
{
    public class ManagerFactory
    {
        public static IManager GetFactory(Entidade entidade)
        {
            IManager managerParaRetorno = null;
            if (entidade.TipoEntidade == TipoClasse.Agente)
            {
                managerParaRetorno = new AgenteManager(entidade as Agente);
            }
            else if (entidade.TipoEntidade == TipoClasse.MosquitoFemea)
            {
                managerParaRetorno = new MosquitoFemeaManager(entidade as MosquitoFemea);
            }
            else if (entidade.TipoEntidade == TipoClasse.MosquitoMacho)
            {
                managerParaRetorno = new MosquitoMachoManager(entidade as MosquitoMacho);
            }
            else if (entidade.TipoEntidade == TipoClasse.Pessoa)
            {
                managerParaRetorno = new PessoaManager(entidade as Pessoa);
            }
            return managerParaRetorno;
        }
    }
}