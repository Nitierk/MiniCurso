using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class DisciplinasController : Controller { 
        bdCursos bd = new bdCursos();
        // GET: Disciplinas
        public ActionResult Index()
        {
            ViewBag.qtdDisciplinas = bd.Disciplinas.ToList().Count();
            return View(bd.Disciplinas.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListaCursos = bd.Cursos.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(string disciplina, string curso, int ch)
        {

            return RedirectToAction("Index");
        }

    }
}