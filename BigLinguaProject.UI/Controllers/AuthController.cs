using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private UserManager<AppUser> userManager = new UserManager<AppUser>(
            new UserStore<AppUser>(new AppDbContext()));
        [HttpGet]
        public ActionResult Register() {
            return View(new UserViewModel());
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel) {
            if (!ModelState.IsValid) {
                return View(userViewModel);
            }
            // 1. Проверить, если ли пользователь с данным Name уже в БД

            // 1a. Есть -- выводим представление регистрации снова с данным сообщением
            // 1b. Нет -- добавляем соответствующую запись в БД и сообщаем об успехе
            AppUser user = new AppUser() { UserName = userViewModel.Name };
            var result = userManager.Create(user, userViewModel.Password);
            if (result.Succeeded) {
                SignIn(user, isPersistent: false);
                ViewBag.UserName = user.UserName;
                return RedirectToAction("index", "home");
            }
            // Для реализации данной схемы следует применить ASP.NET Identity API

            return View("success");
        }
        private void SignIn(AppUser user, Boolean isPersistent) {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { 
                IsPersistent = isPersistent }, identity);
        }
        public ActionResult SignIn() {
            return View();
        }
        public ActionResult SignOut() {
            return null;
        }
        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}