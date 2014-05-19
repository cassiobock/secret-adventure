using secret_adventure.Models;
using secret_adventure.Models.Etc;
using secret_adventure.Models.Manager;
using secret_adventure.Models.Other;
using secret_adventure.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace secret_adventure.Controllers.Api
{
    public class PessoaController : ApiController
    {
        // GET api/pessoa

        public IEnumerable<PessoaViewModel> Get()
        {
            List<Entidade> pessoas = new AmbienteManager(Singleton.GetInstance()).GetListaEntidades(TipoClasse.Pessoa);
            List<PessoaViewModel> pessoasView = new List<PessoaViewModel>();
            foreach (var pessoa in pessoas)
            {
                PessoaViewModel pessoaView = new PessoaViewModel(pessoa as Pessoa);
                pessoasView.Add(pessoaView);
            }
            return pessoasView;
        }

        // GET api/pessoa/5
        public PessoaViewModel Get(string id)
        {
            Entidade entidade = new AmbienteManager(Singleton.GetInstance()).GetEntidade(id);
            PessoaViewModel pessoa = new PessoaViewModel(entidade as Pessoa);
            return pessoa;
        }

    }
}
