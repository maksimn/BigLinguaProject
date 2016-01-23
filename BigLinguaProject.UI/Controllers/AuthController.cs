using System.Web.Mvc;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {        
        public ActionResult Register() {
            return View();
        }
        public ActionResult SignIn() {
            return View();
        }
        public ActionResult SignOut() {
            return null;
        }
    }
}
