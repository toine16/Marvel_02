using Marvel_02.Models;
using Marvel_02.Models.FromAPI;
using Marvel_02.Models.ToView;
using Marvel_02.Tools;
using Marvel_02.Tools.AccesDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Marvel_02.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index(int page = 1)
        {
            CharacterList retour = APIConnection.getCharacterList(page);
            retour.page = page;

            return View(retour);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hero(string sujet)
        {
            
            return View(APIConnection.getCharacter(sujet));
        }


        /// <summary>
        ///         Inscription
        /// </summary>
        /// <returns></returns>
        public ActionResult Inscription()
        {
            return View(new InscriptionModel());
        }
        /// <summary>
        ///         Inscription Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Inscription(InscriptionModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            InscriptionRepository IR = new InscriptionRepository();
            IR.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                PersonneRepository PR = new PersonneRepository();
                if(PR.CheckPassword(model.MotDePasse,model.Login))
                {
                    Session["Pseudo"] = model.Login;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
        }
        public PartialViewResult LoginPartial()
        {
            return PartialView("_Login", new LoginModel());
        }

        public ActionResult Deconnexion()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}