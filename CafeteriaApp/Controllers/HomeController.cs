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

        public ActionResult Inventory()
        {
            var model = _db.Products.ToList();

            return View(model);
        }

        public ActionResult Client()
        {
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