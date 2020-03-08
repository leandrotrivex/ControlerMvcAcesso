using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlerMvcAcesso.Models;

namespace ControlerMvcAcesso.Controllers
{
    public class ALUNOController : Controller
    {
        private DB_CONTROLE_ACESSO_ALUNOEntities db = new DB_CONTROLE_ACESSO_ALUNOEntities();

        // GET: ALUNO
        public ActionResult Index()
        {
            var tB_ALUNO = db.TB_ALUNO.Include(t => t.TB_ADM_USUARIO);
            return View(tB_ALUNO.ToList());
        }

        // GET: ALUNO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ALUNO);
        }

        // GET: ALUNO/Create
        public ActionResult Create()
        {
            ViewBag.COD_ADM_USUARIO = new SelectList(db.TB_ADM_USUARIO, "COD_ADM_USUARIO", "NOME_ADM");
            return View();
        }

        // POST: ALUNO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ALUNO,NOME,RM,NACIMENTO,SEXO,COD_ADM_USUARIO")] TB_ALUNO tB_ALUNO)
        {
            if (ModelState.IsValid)
            {
                db.TB_ALUNO.Add(tB_ALUNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_ADM_USUARIO = new SelectList(db.TB_ADM_USUARIO, "COD_ADM_USUARIO", "NOME_ADM", tB_ALUNO.COD_ADM_USUARIO);
            return View(tB_ALUNO);
        }

        // GET: ALUNO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ADM_USUARIO = new SelectList(db.TB_ADM_USUARIO, "COD_ADM_USUARIO", "NOME_ADM", tB_ALUNO.COD_ADM_USUARIO);
            return View(tB_ALUNO);
        }

        // POST: ALUNO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ALUNO,NOME,RM,NACIMENTO,SEXO,COD_ADM_USUARIO")] TB_ALUNO tB_ALUNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_ALUNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ADM_USUARIO = new SelectList(db.TB_ADM_USUARIO, "COD_ADM_USUARIO", "NOME_ADM", tB_ALUNO.COD_ADM_USUARIO);
            return View(tB_ALUNO);
        }

        // GET: ALUNO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ALUNO);
        }

        // POST: ALUNO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            db.TB_ALUNO.Remove(tB_ALUNO);
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
