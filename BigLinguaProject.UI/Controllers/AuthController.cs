using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private BigLinguaDbContext dbContext = new BigLinguaDbContext();
        private AuthService authService = new AuthService();

        [HttpGet]
        public ActionResult Register() {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel userViewModel) {
            if (!authService.IsRegisterActionViewModelValid(userViewModel, ModelState)) {
                return View(userViewModel);
            }
            String resultModel = authService.GetRegisterActionViewModel(userViewModel);            
            // Результат действия:
            return View("success", resultModel);
        }
        public ActionResult SignIn() {
            return View(new SignInViewModel());
        }
        [HttpPost]
        public ActionResult SignIn(SignInViewModel viewModel, String returnUrl,
            String defaultAction="index", String defaultController="home") {
            Boolean isValidReturnUrl = IsValidReturnUrl(returnUrl);

            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(viewModel);
            }

            // Validate and proceed
            User user = ValidateUser(viewModel.Name, SHA1Util.SHA1HashStringForUTF8String(viewModel.Password));
            if (user.Name != null) {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                if (isValidReturnUrl) {
                    return Redirect(returnUrl);
                }
                return RedirectToAction(defaultAction, defaultController, new { id = user.Name });
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(viewModel);
        }

        public ActionResult SignOut(String defaultAction = "Index", String defaultController = "Home") {
            FormsAuthentication.SignOut();
            return RedirectToAction(defaultAction, defaultController);
        }

        private Boolean IsValidReturnUrl(String returnUrl) {
            return Url.IsLocalUrl(returnUrl) &&
                returnUrl.Length > 1 &&
                returnUrl.StartsWith("/") &&
                !returnUrl.StartsWith("//") &&
                !returnUrl.StartsWith("/\\");
        }
        
        private User ValidateUser(String name, String passwordHash) {
            User user = dbContext.Users.SingleOrDefault(u =>
                String.Equals(u.Name, name) && String.Equals(u.PasswordHash, passwordHash));
            return user;
        }
    }
}