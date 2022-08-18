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
            if (Session["MyCurso"] != null)
            {
                return View(bd.GrupoCursoQtdDisciplinas.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        public ActionResult ErrorBD()
        {
            ViewBag.mensagemErro = Mensagem.textoErro;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarLogin(string login, string senha)
        {
            bool validado = true;
            if (validado)
            {
                Session["MyCurso"] = "MyCurso";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.textoErro = "Login ou Senha incorreto";
                return RedirectToAction("Login");
            }
            return null;
        }
    }
}