using secret_adventure.Models.Base;
using secret_adventure.Models.Etc;
using secret_adventure.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace secret_adventure.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/
        [HttpPost]
        public ActionResult Index(AmbienteViewModel model)
        {
            Singleton.SetInstance(new Ambiente(model.Linhas, model.Colunas, model.NumeroMosquitos, model.NumeroPessoas, model.NumeroAgentes));
            return RedirectToAction("Index", "Ambiente");
        }
    }
}