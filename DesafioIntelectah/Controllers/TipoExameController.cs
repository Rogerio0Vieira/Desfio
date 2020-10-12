using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioIntelectah.Models;

namespace DesafioIntelectah.Controllers
{
    public class TipoExameController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.TiposExames.ToList());
        }
                
        public ActionResult Details(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            TipoExame tipoExame = db.TiposExames.Find(id);

            if (tipoExame == null)           
                return HttpNotFound();
            
            return View(tipoExame);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoExame tipoExame)
        {
            if (ModelState.IsValid)
            {
                db.TiposExames.Add(tipoExame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoExame);
        }
                
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            TipoExame tipoExame = db.TiposExames.Find(id);

            if (tipoExame == null)            
                return HttpNotFound();
            
            return View(tipoExame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoExame tipoExame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoExame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoExame);
        }
                
        public ActionResult Delete(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            TipoExame tipoExame = db.TiposExames.Find(id);
            
            if (tipoExame == null)            
                return HttpNotFound();
            
            return View(tipoExame);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoExame tipoExame = db.TiposExames.Find(id);
            db.TiposExames.Remove(tipoExame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)            
                db.Dispose();
            
            base.Dispose(disposing);
        }
    }
}
