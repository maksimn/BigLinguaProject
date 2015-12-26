using System;
using System.Web.Mvc;
using BigLinguaProject.UI.Models;

namespace BigLinguaProject.UI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user) {
            return RedirectToAction("registered", user);
        }
        public ActionResult Registered(User user) {
            return View(user);
        }
    }
}