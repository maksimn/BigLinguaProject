using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BigLinguaProject.UI.Attributes {
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizedUsersOnlyAttribute : FilterAttribute, IAuthorizationFilter {
        public void OnAuthorization(AuthorizationContext filterContext) {
            // Here we need to check if the user is authorized
            if (filterContext.HttpContext.Session == null) {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }                

            String sessionUserName = (String)filterContext.HttpContext.Session["username"];
            if (sessionUserName == null) {
                filterContext.Result = new HttpUnauthorizedResult();
            } else if (sessionUserName != (filterContext.RouteData.Values["username"] as String)) {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { username = sessionUserName })
                );
            }
        }
    }
}