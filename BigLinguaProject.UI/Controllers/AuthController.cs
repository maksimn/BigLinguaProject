using System.Web.Mvc;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        [HttpGet]
        public ActionResult Register() {
            return View(new UserViewModel());
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel) {
            if (!ModelState.IsValid) {
                return View(userViewModel);
            }
            return View("success");
        }
        public ActionResult SignIn() {
            return View();
        }
        public ActionResult SignOut() {
            return null;
        }
    }
}