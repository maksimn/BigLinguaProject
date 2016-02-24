using System;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class AuthController : Controller {
        private IAuthService authService;

        public AuthController() {
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
            if (!authService.IsViewModelValid<RegisterViewModel>(userViewModel, ModelState)) {
                return View(userViewModel);
            }
            String resultModel = authService.GetActionModelResult<RegisterViewModel>(userViewModel) as String;
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

            if (!authService.IsViewModelValid<SignInViewModel>(viewModel, ModelState)) {
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

        protected override void Dispose(Boolean disposing) {
            if (disposing) {
                authService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}