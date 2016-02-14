using System;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private AuthService authService;

        public AuthController() : base() {
            authService = new AuthService();
        }

        [UnauthorizedUsersOnly]
        public ActionResult Index() {
            return View();
        }

        [UnauthorizedUsersOnly]
        public ActionResult Register() {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel userViewModel) {
            if (!authService.IsRegisterActionViewModelValid(userViewModel, ModelState)) {
                return View(userViewModel);
            }
            var resultModel = authService.GetRegisterActionViewModel(userViewModel);
            CreateSession(userViewModel.Name);
            return View("success", null, resultModel);
        }

        [UnauthorizedUsersOnly]
        public ActionResult SignIn() {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel viewModel, String returnUrl) {
            Boolean isValidReturnUrl = IsValidReturnUrl(returnUrl);

            if (!authService.IsSignInViewModelValid(viewModel, ModelState)) {
                return View(viewModel);
            }

            authService.SignIn(viewModel.Name);
            CreateSession(viewModel.Name);

            if (isValidReturnUrl) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("index", "notebook");
        }

        public ActionResult SignOut(String defaultAction = "Index", String defaultController = "Auth") {
            Boolean authorized = Session["username"] != null;
            if (!authorized) {
                return RedirectToAction(defaultAction, defaultController);
            }

            authService.SignOut();
            RemoveSession();
            return RedirectToAction(defaultAction, defaultController);
        }

        private void CreateSession(String username) {
            Session.Add("username", username);
        }

        private void RemoveSession() {
            Session.Remove("username");
            Session.Abandon();
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