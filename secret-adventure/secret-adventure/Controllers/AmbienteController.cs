using secret_adventure.Models;
using secret_adventure.Models.Base;
using secret_adventure.Models.Etc;
using secret_adventure.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace secret_adventure.Controllers
{
    public class AmbienteController : Controller
    {

        //
        // GET: /Ambiente/
        public ActionResult Index()
        {
            Entidade[,] matriz = new AmbienteManager(Singleton.GetInstance()).GetMatriz();
            return View(matriz);
        }

        //
        // GET: /Tabuleiro/Mover
        public ActionResult Mover()
        {
            AmbienteManager manager = new AmbienteManager(Singleton.GetInstance());
            List<Entidade> entidadesQueJaRealizaramAcao = new List<Entidade>();
            foreach (Entidade entidade in manager.GetListaEntidades())
            {
                if (entidadesQueJaRealizaramAcao.Where(p => p.Id == entidade.Id).Count() == 0 && entidade.Ativo == true)
                {
                    entidadesQueJaRealizaramAcao.Add(entidade);
                    new EntidadeManager(entidade).Agir();
                }
            }
            manager.Processar();
            return View(manager.GetMatriz());
        }
    }
}