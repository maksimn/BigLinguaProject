using System;
using System.Web.Mvc;

namespace BigLinguaProject.UI.Services {
    public interface IAuthService : IDisposable {
        Boolean IsViewModelValid<T>(T viewModel, ModelStateDictionary modelState);
        Object GetActionModelResult<T1>(T1 viewModel);
        void SignIn<T2>(T2 data);
        void SignOut();
    }
}