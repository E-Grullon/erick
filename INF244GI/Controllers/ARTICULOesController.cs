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
    public class ARTICULOesController : Controller
    {
        private GestionInventarioEntities db = new GestionInventarioEntities();

        // GET: ARTICULOes
        public ActionResult Index()
        {
            var aRTICULO = db.ARTICULO.Include(a => a.TIPOINVENTARIO);
            return View(aRTICULO.ToList());
        }

        // GET: ARTICULOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // GET: ARTICULOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIO, "ID_TIPOINVENTARIO", "DESCRIPCION");
            return View();
        }

        // POST: ARTICULOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,DESCRIPCION_ARTICULO,EXISTENCIA_ARTICULO,ID_TIPOINVENTARIO,COSTOUNITARIO,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULO.Add(aRTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIO, "ID_TIPOINVENTARIO", "DESCRIPCION", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // GET: ARTICULOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIO, "ID_TIPOINVENTARIO", "DESCRIPCION", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // POST: ARTICULOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,DESCRIPCION_ARTICULO,EXISTENCIA_ARTICULO,ID_TIPOINVENTARIO,COSTOUNITARIO,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPOINVENTARIO = new SelectList(db.TIPOINVENTARIO, "ID_TIPOINVENTARIO", "DESCRIPCION", aRTICULO.ID_TIPOINVENTARIO);
            return View(aRTICULO);
        }

        // GET: ARTICULOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // POST: ARTICULOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            db.ARTICULO.Remove(aRTICULO);
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
