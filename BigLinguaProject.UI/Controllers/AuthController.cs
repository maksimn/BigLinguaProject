using System.Linq;
using System.Web.Mvc;
using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private BigLinguaDbContext dbContext = new BigLinguaDbContext();

        [HttpGet]
        public ActionResult Register() {
            return View(new UserViewModel());
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel) {
            if (!ModelState.IsValid) {
                return View(userViewModel);
            }
            // Если в базе уже существует пользователь с данным именем, попросить ввести заново
            if(dbContext.Users.Any(u => u.Name == userViewModel.Name)) {
                ModelState.AddModelError("Name", 
                    "A user with this name already exists. Please try again with another name.");
                return View(userViewModel);
            }
            // Если нет, добавить в базу и авторизовать в системе
            User user = new User {
                Name = userViewModel.Name,
                PasswordHash = SHA1Util.SHA1HashStringForUTF8String(userViewModel.Password)
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            // Теперь нужно авторизовать данного пользователя
            AuthorizeUser(user);

            return View("success");
        }
        public ActionResult SignIn() {
            return View();
        }
        public ActionResult SignOut() {
            return null;
        }
        private void AuthorizeUser(User user) {
            this.HttpContext.Session["UserName"] = user.Name;
        }
    }
}