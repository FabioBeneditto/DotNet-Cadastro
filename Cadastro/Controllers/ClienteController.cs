using Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}