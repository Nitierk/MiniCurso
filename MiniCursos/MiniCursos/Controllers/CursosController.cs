using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class CursosController : Controller
    {
        bdCursos bd = new bdCursos();
        // GET: Cursos
        public ActionResult Index()
        {
            ViewBag.qtdCursos = bd.Cursos.ToList().Count();
            return View(bd.Cursos.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string nome, string habilidade, string modalidade)
        {
            Cursos novocurso = new Cursos();
            novocurso.CURSODESCRICAO = nome;
            novocurso.CURSOCODHABILIDADE = habilidade;
            novocurso.CURSOMODALIDADE = modalidade;

            bd.Cursos.Add(novocurso);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}