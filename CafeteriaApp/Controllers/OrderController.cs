using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeteriaApp.Models;

namespace CafeteriaApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private CafeteriaDb db = new CafeteriaDb();

        // GET: /Order/
        public ActionResult Index(String searchTerm, String type)
        {
            if (searchTerm != null && type != null)
            {   
                if(type == "State")
                {
                    if(searchTerm == "Despachada")
                        return View(db.Orders.Where(Order => Order.Estado == true));
                    else
                        return View(db.Orders.Where(Order => Order.Estado == false));
                }
                else if(type == "noFac")
                {
                    int id = int.Parse(searchTerm);
                        return View(db.Orders.Where(Order => Order.Id == id));
                }
                else if(type == "Art")
                {
                        int cantidad = int.Parse(searchTerm);
                        return View(db.Orders.Where(Order => Order.Id == cantidad));
                }
                else if(type == "Cli" || type == "Empl")
                {
                    return View(db.Orders.Where(Order => 
                                            type=="Cli"  && Order.Cliente.Contains(searchTerm) ||
                                            type=="Empl" && Order.Empleado.Contains(searchTerm)) );
                }
                else if(type == "Date")
                {
                    DateTime date = DateTime.Parse(searchTerm);
                    return View(db.Orders.Where(Order => Order.Fecha == date));
                
                }          
           }
            return View(db.Orders.ToList());
        }

        // GET: /Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Cliente,Articulos,Empleado,Total,Fecha,Estado")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: /Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Cliente,Articulos,Empleado,Total,Fecha,Estado")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
