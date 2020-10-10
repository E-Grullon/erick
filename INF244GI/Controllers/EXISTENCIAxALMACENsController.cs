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
    public class EXISTENCIAxALMACENsController : Controller
    {
        private GestionInventarioEntities db = new GestionInventarioEntities();

        // GET: EXISTENCIAxALMACENs
        public ActionResult Index()
        {
            var eXISTENCIAxALMACEN = db.EXISTENCIAxALMACEN.Include(e => e.ALMACEN).Include(e => e.ARTICULO);
            return View(eXISTENCIAxALMACEN.ToList());
        }

        // GET: EXISTENCIAxALMACENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXISTENCIAxALMACEN eXISTENCIAxALMACEN = db.EXISTENCIAxALMACEN.Find(id);
            if (eXISTENCIAxALMACEN == null)
            {
                return HttpNotFound();
            }
            return View(eXISTENCIAxALMACEN);
        }

        // GET: EXISTENCIAxALMACENs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ALMACEN = new SelectList(db.ALMACEN, "ID_ALMACEN", "DESCRIPCION");
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULO, "ID_ARTICULO", "DESCRIPCION_ARTICULO");
            return View();
        }

        // POST: EXISTENCIAxALMACENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,ID_ALMACEN,CANTIDAD")] EXISTENCIAxALMACEN eXISTENCIAxALMACEN)
        {
            if (ModelState.IsValid)
            {
                db.EXISTENCIAxALMACEN.Add(eXISTENCIAxALMACEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ALMACEN = new SelectList(db.ALMACEN, "ID_ALMACEN", "DESCRIPCION", eXISTENCIAxALMACEN.ID_ALMACEN);
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULO, "ID_ARTICULO", "DESCRIPCION_ARTICULO", eXISTENCIAxALMACEN.ID_ARTICULO);
            return View(eXISTENCIAxALMACEN);
        }

        // GET: EXISTENCIAxALMACENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXISTENCIAxALMACEN eXISTENCIAxALMACEN = db.EXISTENCIAxALMACEN.Find(id);
            if (eXISTENCIAxALMACEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALMACEN = new SelectList(db.ALMACEN, "ID_ALMACEN", "DESCRIPCION", eXISTENCIAxALMACEN.ID_ALMACEN);
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULO, "ID_ARTICULO", "DESCRIPCION_ARTICULO", eXISTENCIAxALMACEN.ID_ARTICULO);
            return View(eXISTENCIAxALMACEN);
        }

        // POST: EXISTENCIAxALMACENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,ID_ALMACEN,CANTIDAD")] EXISTENCIAxALMACEN eXISTENCIAxALMACEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eXISTENCIAxALMACEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALMACEN = new SelectList(db.ALMACEN, "ID_ALMACEN", "DESCRIPCION", eXISTENCIAxALMACEN.ID_ALMACEN);
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULO, "ID_ARTICULO", "DESCRIPCION_ARTICULO", eXISTENCIAxALMACEN.ID_ARTICULO);
            return View(eXISTENCIAxALMACEN);
        }

        // GET: EXISTENCIAxALMACENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXISTENCIAxALMACEN eXISTENCIAxALMACEN = db.EXISTENCIAxALMACEN.Find(id);
            if (eXISTENCIAxALMACEN == null)
            {
                return HttpNotFound();
            }
            return View(eXISTENCIAxALMACEN);
        }

        // POST: EXISTENCIAxALMACENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EXISTENCIAxALMACEN eXISTENCIAxALMACEN = db.EXISTENCIAxALMACEN.Find(id);
            db.EXISTENCIAxALMACEN.Remove(eXISTENCIAxALMACEN);
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
