using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeteriaApp.Models;
using Microsoft.Reporting.WebForms;
using System.IO;
using CafeteriaApp.Attributes;

namespace CafeteriaApp.Controllers
{
    [AuthorizePimpedAttribute]
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

        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "Reporte.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Order> cm = new List<Order>();
            cm = db.Orders.ToList();
            
            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>11in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);
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
