using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class HomeController : Controller
    {
        bdCursos bd = new bdCursos();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DashboardCursos()
        {
            return View(bd.GrupoCursoQtdDisciplinas.ToList());
        }

        public ActionResult ErrorBD()
        {
            ViewBag.mensagemErro = Mensagem.textoErro;
            return View();
        }
    }
}