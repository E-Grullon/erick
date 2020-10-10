using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INF244GI;

namespace INF244GI.Controllers
{
    public class TIPOINVENTARIOsController : Controller
    {
        private GestionInventarioEntities db = new GestionInventarioEntities();

        // GET: TIPOINVENTARIOs
        public ActionResult Index()
        {
            return View(db.TIPOINVENTARIO.ToList());
        }

        // GET: TIPOINVENTARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIO.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOINVENTARIOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPOINVENTARIO,DESCRIPCION,CUENTA_CONTABLE,ESTADO")] TIPOINVENTARIO tIPOINVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOINVENTARIO.Add(tIPOINVENTARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIO.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // POST: TIPOINVENTARIOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPOINVENTARIO,DESCRIPCION,CUENTA_CONTABLE,ESTADO")] TIPOINVENTARIO tIPOINVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOINVENTARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOINVENTARIO);
        }

        // GET: TIPOINVENTARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIO.Find(id);
            if (tIPOINVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOINVENTARIO);
        }

        // POST: TIPOINVENTARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOINVENTARIO tIPOINVENTARIO = db.TIPOINVENTARIO.Find(id);
            db.TIPOINVENTARIO.Remove(tIPOINVENTARIO);
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
