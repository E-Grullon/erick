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
    public class ALMACENsController : Controller
    {
        private GestionInventarioEntities db = new GestionInventarioEntities();

        // GET: ALMACENs
        public ActionResult Index()
        {
            return View(db.ALMACEN.ToList());
        }

        // GET: ALMACENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACEN.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // GET: ALMACENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALMACENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALMACEN,DESCRIPCION,ESTADO")] ALMACEN aLMACEN)
        {
            if (ModelState.IsValid)
            {
                db.ALMACEN.Add(aLMACEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLMACEN);
        }

        // GET: ALMACENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACEN.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // POST: ALMACENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALMACEN,DESCRIPCION,ESTADO")] ALMACEN aLMACEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLMACEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLMACEN);
        }

        // GET: ALMACENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALMACEN aLMACEN = db.ALMACEN.Find(id);
            if (aLMACEN == null)
            {
                return HttpNotFound();
            }
            return View(aLMACEN);
        }

        // POST: ALMACENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALMACEN aLMACEN = db.ALMACEN.Find(id);
            db.ALMACEN.Remove(aLMACEN);
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
