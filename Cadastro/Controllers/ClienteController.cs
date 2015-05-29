using Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Cadastro.Controllers
{
    public class ClienteController : Controller
    {
        CadastroEntities db = new CadastroEntities();

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> lstClientes = db.Cliente.ToList<Cliente>();
            return View(lstClientes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Nome, DataNascimento, Email, Telefone")] Cliente cliParaSalvar)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Cliente.Add(cliParaSalvar);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar o CLiente." + ex.Message);
            }
            return View();
        }

        // GET
        public ActionResult Edit(int id)
        {
            // Cliente cli = db.Cliente.Find(id);
            Cliente cli = db.Cliente.First<Cliente>(c => c.codigo == id);

            return View(cli);
        }

        // POST
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id) // Poderia vir NULL, por isso a ? 
        {
            if( ! id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliAtualizar = db.Cliente.Find(id);
            if (TryUpdateModel(cliAtualizar, "", new string[] { "Nome", "DataNascimento", "Email", "Telefone" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Não foi possível alterar o cliente." + ex.Message);
                }
            }
            return View(cliAtualizar);
        }

        public ActionResult Delete(int id)
        {
            Cliente cliDelete = db.Cliente.First<Cliente>(c => c.codigo == id);
            return View(cliDelete);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliForDel = db.Cliente.Find(id);
            try
            {
                db.Cliente.Remove(cliForDel);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível excluir o cliente." + ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}