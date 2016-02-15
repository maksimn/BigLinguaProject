using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BigLinguaProject.UI.Attributes {
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizedUsersOnlyAttribute : FilterAttribute, IActionFilter {
        public void OnActionExecuted(ActionExecutedContext filterContext) {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {
            // Here we need to check if the user is authorized
            if (filterContext.HttpContext.Session == null) {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            String sessionUserName = (String)filterContext.HttpContext.Session["username"];
            String routeUserName = (String)filterContext.RouteData.Values["username"];
            Boolean isAuthorized = sessionUserName != null;
            Boolean authorizedAndSessionAndRouteUserNamesTheSame = 
                isAuthorized && sessionUserName == routeUserName;
            
            if(!isAuthorized) {
                filterContext.Result = new HttpUnauthorizedResult();
            } else if (!authorizedAndSessionAndRouteUserNamesTheSame) {
                filterContext.Result = new RedirectResult(String.Format("{0}/notebook/index", sessionUserName));
            } 
        }
    }
}