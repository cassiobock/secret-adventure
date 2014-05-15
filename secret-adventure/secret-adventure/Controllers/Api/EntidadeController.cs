using secret_adventure.Models;
using secret_adventure.Models.Etc;
using secret_adventure.Models.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace secret_adventure.Controllers.Api
{
    public class EntidadeController : ApiController
    {


        public IEnumerable<Entidade> GetAllEntidades()
        {
            return new AmbienteManager(Singleton.GetInstance()).GetListaEntidades();
        }

        public Entidade GetEntidade(int posicao)
        {
            Entidade entidade = new AmbienteManager(Singleton.GetInstance()).GetListaEntidades()[posicao];
            if (entidade == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return entidade;
        }
    }
}
