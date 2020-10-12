using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioIntelectah.Models;
using DesafioIntelectah.Models.ViewModel;

namespace DesafioIntelectah.Controllers
{
    public class ExameController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.Exames.ToList());
        }
                
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Exame exame = db.Exames.Find(id);

            if (exame == null)
                return HttpNotFound();

            return View(exame);
        }
                
        public ActionResult Create()
        {
            ExameViewModel tipoExameViewModel = new ExameViewModel();
            var tipoExames = db.TiposExames.ToList();

            foreach (var item in tipoExames)
            {
                tipoExameViewModel.ListarTiposExamesViewModel.Add(new SelectListItem()
                {
                    Text = Convert.ToString(item.CodigoTipoExame) + " - " + item.NomeTipoExame,
                    Value = Convert.ToString(item.CodigoTipoExame)
                });
            }

            return View(tipoExameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exame exame)
        {
            if (ModelState.IsValid)
            {
                db.Exames.Add(exame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exame);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Exame exame = db.Exames.Find(id);

            if (exame == null)
                return HttpNotFound();

            ExameViewModel tipoExameViewModel = new ExameViewModel();
            var tipoExames = db.TiposExames.ToList();

            foreach (var item in tipoExames)
            {
                tipoExameViewModel.ListarTiposExamesViewModel.Add(new SelectListItem()
                {
                    Text = Convert.ToString(item.CodigoTipoExame) + " - " + item.NomeTipoExame,
                    Value = Convert.ToString(item.CodigoTipoExame)                    
                });
            }
                        
            tipoExameViewModel.CodigoExame = exame.CodigoExame;
            tipoExameViewModel.IdTipoExame = exame.IdTipoExame;
            tipoExameViewModel.NomeExame = exame.NomeExame;
            tipoExameViewModel.ObservacaoExame = exame.ObservacaoExame;
                        
            return View(tipoExameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exame exame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exame);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Exame exame = db.Exames.Find(id);

            if (exame == null)
                return HttpNotFound();

            return View(exame);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exame exame = db.Exames.Find(id);
            db.Exames.Remove(exame);
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
