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
            user.Password = SHA1Util.SHA1HashStringForUTF8String(user.Password);
            return RedirectToAction("registered", user);
        }
        public ActionResult Registered(User user) {
            return View(user);
        }
    }
}