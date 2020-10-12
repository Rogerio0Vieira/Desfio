using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioIntelectah.Models;
using DesafioIntelectah.BLL;

namespace DesafioIntelectah.Controllers
{
    public class PacienteController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.Pacientes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente paciente = db.Pacientes.Find(id);

            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            PacienteValido pacienteValido = new PacienteValido();

            if (!pacienteValido.CpfPacienteValido(paciente.CpfPaciente))
            {
                TempData[Constantes.MensagemAlerta] = "O CPF digitado é inválido ou não existe.";
            }
            else
            {
                var result = db.Pacientes.FirstOrDefault(p => p.CpfPaciente == paciente.CpfPaciente);

                if (ModelState.IsValid)
                {
                    if (result == null)
                    {
                        db.Pacientes.Add(paciente);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData[Constantes.MensagemAlerta] = "O CPF digitado está vinculado a outro paciente.";
                    }
                }
            }           

            return View(paciente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente paciente = db.Pacientes.Find(id);

            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {            
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);            
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Paciente paciente = db.Pacientes.Find(id);
            
            if (paciente == null)            
                return HttpNotFound();
            
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
