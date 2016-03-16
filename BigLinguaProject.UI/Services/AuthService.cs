using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.Models.Entities;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class AuthService : IAuthService {
        private BigLinguaDbContext1 dbContext = new BigLinguaDbContext1();

        private Boolean IsRegisterActionViewModelValid(RegisterViewModel viewModel, 
                                                      ModelStateDictionary modelState) {
            if(!modelState.IsValid) {
                return false;
            }
            if (dbContext.Users.Any(u => u.Name == viewModel.Name)) {
                modelState.AddModelError("Name",
                    "A user with this name already exists. Please try again with another name.");
                return false;
            }
            return true;
        }

        private String GetRegisterActionViewModel(RegisterViewModel viewModel) {
            // добавить в базу и авторизовать в системе
            User user = new User {
                Name = viewModel.Name,
                PasswordHash = SHA1Util.SHA1HashStringForUTF8String(viewModel.Password)
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            // Теперь нужно авторизовать данного пользователя
            SignIn(user.Name);
            return user.Name;
        }

        private void SignIn(String userName) {
            FormsAuthentication.SetAuthCookie(userName, false);
        }

        private Boolean IsSignInViewModelValid(SignInViewModel viewModel, ModelStateDictionary modelState) {
            if (!modelState.IsValid || 
                !DoesUserExistInDb(viewModel.Name, SHA1Util.SHA1HashStringForUTF8String(viewModel.Password))) {
                modelState.AddModelError("", "The user name or password provided is incorrect.");
                return false;
            }
            return true;
        }

        private Boolean DoesUserExistInDb(String name, String passwordHash) {
            return dbContext.Users.Any(u =>
                String.Equals(u.Name, name) && String.Equals(u.PasswordHash, passwordHash));
        }

        public Boolean IsViewModelValid<T>(T viewModel, ModelStateDictionary modelState) {
            if (viewModel is RegisterViewModel) {
                return IsRegisterActionViewModelValid(viewModel as RegisterViewModel, modelState);
            } else if (viewModel is SignInViewModel) {
                return IsSignInViewModelValid(viewModel as SignInViewModel, modelState);
            } else {
                throw new NotImplementedException();
            }            
        }

        public Object GetActionModelResult<T1>(T1 viewModel) {
            if (viewModel is RegisterViewModel) {
                return GetRegisterActionViewModel(viewModel as RegisterViewModel);
            } else {
                throw new NotImplementedException();
            }  
        }

        public void SignIn<T2>(T2 data) {
            if (data is String) {
                SignIn(data as String);
            } else {
                throw new NotImplementedException();
            }
        }

        public void SignOut() {
            FormsAuthentication.SignOut();
        }

        public void Dispose() {
            dbContext.Dispose();
        }
    }
}