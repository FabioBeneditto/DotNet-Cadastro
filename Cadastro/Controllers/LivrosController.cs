using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cadastro.Models;
using Cadastro.Models.ViewModels;

namespace Cadastro.Controllers
{
    public class LivrosController : Controller
    {
        private CadastroEntities db = new CadastroEntities();

        // GET: Livros
        public ActionResult Index()
        {
            //var livro = db.Livro.Include(l => l.Autor).Include(l => l.Genero);
            //return View(livro.ToList());
            List<Livro> lstLivro = db.Livro.ToList<Livro>();
            return View(lstLivro);
        }

        public ActionResult Create()
        {
            LivroCreate modelo = new LivroCreate();
            modelo.Autor = db.Autor.ToList<Autor>();
            modelo.Genero = db.Genero.ToList<Genero>();
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Titulo, NumPaginas, Ano, Editora, Preco, CodAutor, codGenero")] Livro pLivro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Livro.Add(pLivro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar o livro. " + ex.Message);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Livro l = db.Livro.Find(id);
            LivroCreate modelo_para_tela = new LivroCreate();

            // AutoMapper = Mapear diretamente
            modelo_para_tela.CodLivro = l.CodLivro;
            modelo_para_tela.Titulo = l.Titulo;
            modelo_para_tela.NumPaginas = l.NumPaginas;
            modelo_para_tela.Editora = l.Editora;
            modelo_para_tela.Ano = l.Ano;
            modelo_para_tela.Preco = l.Preco;
            modelo_para_tela.CodAutor = l.CodAutor;
            modelo_para_tela.codGenero = l.codGenero;

            modelo_para_tela.Autor = db.Autor.ToList<Autor>();
            modelo_para_tela.Genero = db.Genero.ToList<Genero>();

            return View(modelo_para_tela);
        }
    }
}
