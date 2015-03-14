using CafeteriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeteriaApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        CafeteriaDb _db = new CafeteriaDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory(String searchTerm, String type)
        {
            if (searchTerm != null && type != null)
            {
                if (type == "State")
                {
                    if (searchTerm == "Activo")
                        return View(_db.Products.Where(Product => Product.Estado ==  "Activo"));
                    else
                        return View(_db.Products.Where(Product => Product.Estado ==  "Inactivo"));
                }
                else if(type == "Cod")
                {
                    return View(_db.Products.Where(Product => Product.Codigo == searchTerm));
                }
                else if (type == "Cost")
                {
                    double costo = double.Parse(searchTerm);
                    return View(_db.Products.Where(Product => Product.Costo == costo));
                }
                else if (type == "Desc")
                {
                    return View(_db.Products.Where(Product => Product.Descripcion.Contains(searchTerm)));
                }
                else if (type == "Marc")
                {
                    return View(_db.Products.Where(Product => Product.Marca.Contains(searchTerm) ));
                }
                else if (type == "Prov")
                {
                    return View(_db.Products.Where(Product => Product.Proveedor.Contains(searchTerm)));

                }
                else if (type == "Exist")
                {
                    int Existencia = int.Parse(searchTerm);
                    return View(_db.Products.Where(Product => Product.Existencia == Existencia));

                }
            }
            var model = _db.Products.ToList();

            return View(model);
        }

        public ActionResult Client(String searchTerm, String type)
        {
            if (type == "State")
            {
                if (searchTerm == "Activo")
                    return View(_db.Clients.Where(Client => Client.Estado == "Activo"));
                else
                    return View(_db.Clients.Where(Client => Client.Estado == "Inactivo"));
            }
            else if (type == "Ident")
            {
                return View(_db.Clients.Where(Client => Client.Identificador == searchTerm));
            }
            else if (type == "Cred")
            {
                double credito = double.Parse(searchTerm);
                return View(_db.Clients.Where(Client => Client.Credito == credito));
            }
            else if (type == "Nomb")
            {
                return View(_db.Clients.Where(Client => Client.Nombre.Contains(searchTerm)));
            }
            else if (type == "Ced")
            {
                return View(_db.Clients.Where(Client => Client.Cedula == searchTerm));
            }
            else if (type == "tipo")
            {
                return View(_db.Clients.Where(Client => Client.Tipo == searchTerm));
            }
            else if (type == "Reg")
            {
                DateTime date = DateTime.Parse(searchTerm);
                return View(_db.Clients.Where(Client => Client.Registro == date));

            }    

            var model = _db.Clients.ToList();

            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}