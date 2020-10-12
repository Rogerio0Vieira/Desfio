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
    public class ConsultaController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.Consultas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
                return HttpNotFound();

            return View(consulta);
        }

        public ActionResult Create()
        {
            ConsultaViewModel tipoExameConsultaViewModel = new ConsultaViewModel();
            var tipoExamesConsulta = db.TiposExames.ToList();

            foreach (var item in tipoExamesConsulta)
            {
                tipoExameConsultaViewModel.ListarTiposExameConsultaViewModel.Add(new SelectListItem()
                {
                    Text = Convert.ToString(item.CodigoTipoExame) + " - " + item.NomeTipoExame,
                    Value = Convert.ToString(item.CodigoTipoExame),
                    Selected = true
                });
            }

            return View(tipoExameConsultaViewModel);
        }

        [HttpGet]
        public JsonResult ConsultarPacienteCpfJR(string cpfPesquisaPaciente)
        {
            var result = db.Pacientes.FirstOrDefault(p => p.CpfPaciente == cpfPesquisaPaciente);
            return Json(result, JsonRequestBehavior.AllowGet);          
        }

        [HttpGet]
        public JsonResult ConsultarListaExamesJR(int idTipoExame)
        {
            var result = db.Exames.Where(p => p.IdTipoExame == idTipoExame).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            Random random = new Random();

            if (ModelState.IsValid)
            {        
                consulta.ProtocoloConsulta = Convert.ToString(random.Next());

                var result = db.Consultas.FirstOrDefault(p => p.DataHoraConsulta == consulta.DataHoraConsulta && p.HorasConsulta == consulta.HorasConsulta && p.MinutosConsulta == consulta.MinutosConsulta);

                if (result != null)
                {
                    TempData[Constantes.MensagemAlerta] = "Já existe uma consulta nesse horário.";
                    return RedirectToAction("Create");
                }
                else
                {
                    db.Consultas.Add(consulta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }

            return View(consulta);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
                return HttpNotFound();

            return View(consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consulta);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
                return HttpNotFound();

            return View(consulta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consultas.Find(id);
            db.Consultas.Remove(consulta);
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
