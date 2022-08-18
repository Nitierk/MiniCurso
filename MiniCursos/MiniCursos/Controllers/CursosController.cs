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
            if (Session["MyCurso"] != null)
            {
                return View(bd.Cursos.ToList());
            }
            else
            {
                Mensagem.textoErro = "Faça Login";
                return RedirectToAction("Login", "Home");
            }
          
            
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
            Cursos ultimoCurso = bd.Cursos.ToList().Last();
            int ultimoID = ultimoCurso.CURSOID;
            novocurso.CURSOID = ultimoID + 1;

            

            bd.Cursos.Add(novocurso);
                bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Cursos excluirCurso = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            return View(excluirCurso);
        }
        [HttpPost]
        public ActionResult DeleteConfirmar(int? id)
        {
            Cursos excluirCurso = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            bd.Cursos.Remove(excluirCurso);
            try
            {
                bd.SaveChanges();
            }
            catch (Exception e)
            {
                Mensagem.textoErro = "Não é Possivel excluir um Curso já relacionado a uma Disciplina";
                return RedirectToAction("ErrorBd", "Home");
            }
            return RedirectToAction("Index");   
        }


        [HttpGet]
        public ActionResult Exibir(int? id)
        {
            Cursos exibirCurso = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            return View(exibirCurso);
        }

        public ActionResult Editar(int id)
        {
            Cursos editarCurso = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            return View(editarCurso);
        }

        public ActionResult DisciplinasPorCurso(int? id)
        {
            return View(bd.Disciplinas.ToList().ToList().Where(x => x.CURSOID == id));
        }
        
    }
}