using System;
using System.Web.Mvc;

using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private AuthService authService = new AuthService();

        public ActionResult Register() {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel userViewModel) {
            if (!authService.IsRegisterActionViewModelValid(userViewModel, ModelState)) {
                return View(userViewModel);
            }
            var resultModel = authService.GetRegisterActionViewModel(userViewModel); 
            return View("success", null, resultModel);
        }

        public ActionResult SignIn() {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel viewModel, String returnUrl,
            String defaultAction="index", String defaultController="home") {
            Boolean isValidReturnUrl = IsValidReturnUrl(returnUrl);

            if (!authService.IsSignInViewModelValid(viewModel, ModelState)) {
                return View(viewModel);
            }

            authService.SignIn(viewModel.Name);

            if (isValidReturnUrl) {
                return Redirect(returnUrl);
            }
            return RedirectToAction(defaultAction, defaultController, new { id = viewModel.Name });
        }

        public ActionResult SignOut(String defaultAction = "Index", String defaultController = "Home") {
            authService.SignOut();
            return RedirectToAction(defaultAction, defaultController);
        }

        private Boolean IsValidReturnUrl(String returnUrl) {
            return Url.IsLocalUrl(returnUrl) &&
                returnUrl.Length > 1 &&
                returnUrl.StartsWith("/") &&
                !returnUrl.StartsWith("//") &&
                !returnUrl.StartsWith("/\\");
        }
    }
}