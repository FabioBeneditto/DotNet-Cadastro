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
    }
}