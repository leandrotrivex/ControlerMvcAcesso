using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ControlerMvcAcesso.Models;

namespace ControlerMvcAcesso.Controllers
{
    public class AdmController : Controller
    {
        private DB_CONTROLE_ACESSO_ALUNOEntities db = new DB_CONTROLE_ACESSO_ALUNOEntities();

        // GET: Adm
        public ActionResult Index()
        {
            return View(db.TB_ADM_USUARIO.ToList());
        }

        // GET: Adm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ADM_USUARIO tB_ADM_USUARIO = db.TB_ADM_USUARIO.Find(id);
            if (tB_ADM_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ADM_USUARIO);
        }

        // GET: Adm/Create
        public ActionResult Create()
        { 
            
            return View();
        }

        // POST: Adm/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ADM_USUARIO,NOME_ADM,SOBRENOME,EMAIL,SENHA,PERFIL,ATIVO")] TB_ADM_USUARIO tB_ADM_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TB_ADM_USUARIO.Add(tB_ADM_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_ADM_USUARIO);
        }

        // GET: Adm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ADM_USUARIO tB_ADM_USUARIO = db.TB_ADM_USUARIO.Find(id);
            if (tB_ADM_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ADM_USUARIO);
        }

        // POST: Adm/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ADM_USUARIO,NOME_ADM,SOBRENOME,EMAIL,SENHA,PERFIL,ATIVO")] TB_ADM_USUARIO tB_ADM_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_ADM_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_ADM_USUARIO);
        }

        // GET: Adm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ADM_USUARIO tB_ADM_USUARIO = db.TB_ADM_USUARIO.Find(id);
            if (tB_ADM_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ADM_USUARIO);
        }

        // POST: Adm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_ADM_USUARIO tB_ADM_USUARIO = db.TB_ADM_USUARIO.Find(id);
            db.TB_ADM_USUARIO.Remove(tB_ADM_USUARIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new TB_ADM_USUARIO());

        }
        /// <param name = "login" ></ param >
        /// < param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TB_ADM_USUARIO login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (DB_CONTROLE_ACESSO_ALUNOEntities db = new DB_CONTROLE_ACESSO_ALUNOEntities())
                {
                    var vLogin = db.TB_ADM_USUARIO.Where(p => p.EMAIL.Equals(login.EMAIL)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia. 
                    Isso pode ocorrer caso o usuário não existe. 
              Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {
                        /*Código abaixo verifica se o usuário que retornou na variavel tem está 
                          ativo. Caso não esteja cai direto no else*/
                        if (Equals(vLogin.ATIVO, "S"))
                        {
                            /*Código abaixo verifica se a senha digitada no site é igual a 
                            senha que está sendo retornada 
                             do banco. Caso não cai direto no else*/
                            if (Equals(vLogin.SENHA, login.SENHA))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.EMAIL, false);
                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }
                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["Nome"] = vLogin.NOME_ADM;
                                /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                                Session["Sobrenome"] = vLogin.SOBRENOME;
                                /*retorna para a tela inicial do Home*/
                                return RedirectToAction("Index", "Adm");
                            }
                            /*Else responsável da validação da senha*/
                            else
                            {
                                /*Escreve na tela a mensagem de erro informada*/
                                ModelState.AddModelError("", "Senha informada Inválida!!!");
                                /*Retorna a tela de login*/
                                return View(new TB_ADM_USUARIO());
                            }
                        }
                        /*Else responsável por verificar se o usuário está ativo*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!!!");
                            /*Retorna a tela de login*/
                            return View(new TB_ADM_USUARIO());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "E-mail informado inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new TB_ADM_USUARIO());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login 
            com as mensagem dos campos*/
            return View(login);
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
