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
    public class AutorizacaoController : Controller
    {
        private DB_CONTROLEACESSOEntities db = new DB_CONTROLEACESSOEntities();

        // GET: Autorizacao
        public ActionResult Index()
        {
            var tB_AUTORIZACAO = db.TB_AUTORIZACAO.Include(t => t.TB_ALUNO);
            return View(tB_AUTORIZACAO.ToList());
        }

        // GET: Autorizacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AUTORIZACAO tB_AUTORIZACAO = db.TB_AUTORIZACAO.Find(id);
            if (tB_AUTORIZACAO == null)
            {
                return HttpNotFound();
            }
            return View(tB_AUTORIZACAO);
        }

        // GET: Autorizacao/Create
        public ActionResult Create()
        {
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME");
            return View();
        }

        // POST: Autorizacao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AUTORIZACAO,NOME_RESPONSAVEL,RG,DATA,HORA,TIPO_AUTORIZACAO,VIGENCIA_INICIO,VIGENCIA_FIM,MOTIVO,COD_ALUNO")] TB_AUTORIZACAO tB_AUTORIZACAO)
        {
            if (ModelState.IsValid)
            {
                db.TB_AUTORIZACAO.Add(tB_AUTORIZACAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_AUTORIZACAO.COD_ALUNO);
            return View(tB_AUTORIZACAO);
        }

        // GET: Autorizacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AUTORIZACAO tB_AUTORIZACAO = db.TB_AUTORIZACAO.Find(id);
            if (tB_AUTORIZACAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_AUTORIZACAO.COD_ALUNO);
            return View(tB_AUTORIZACAO);
        }

        // POST: Autorizacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AUTORIZACAO,NOME_RESPONSAVEL,RG,DATA,HORA,TIPO_AUTORIZACAO,VIGENCIA_INICIO,VIGENCIA_FIM,MOTIVO,COD_ALUNO")] TB_AUTORIZACAO tB_AUTORIZACAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_AUTORIZACAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_AUTORIZACAO.COD_ALUNO);
            return View(tB_AUTORIZACAO);
        }

        // GET: Autorizacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AUTORIZACAO tB_AUTORIZACAO = db.TB_AUTORIZACAO.Find(id);
            if (tB_AUTORIZACAO == null)
            {
                return HttpNotFound();
            }
            return View(tB_AUTORIZACAO);
        }

        // POST: Autorizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_AUTORIZACAO tB_AUTORIZACAO = db.TB_AUTORIZACAO.Find(id);
            db.TB_AUTORIZACAO.Remove(tB_AUTORIZACAO);
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
