using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.ActionFilters
{
    public class RequireToken : AuthorizeAttribute
    {
        private readonly IUnitOfWork uow;

        public RequireToken()
        {
            uow = DependencyResolver.Current.GetService<IUnitOfWork>(); ;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = httpContext.Request.Headers["X-Api-Token"];
            
            if (token == null) return false;
            
            var tokenService = uow.GetRepository<ApiToken>();
            var foundToken = tokenService.Query()
                .FirstOrDefault(t => t.Key == token);

            var isValid = foundToken != null &&
                          !foundToken.ExplicitExpirationDate.HasValue &&
                          foundToken.ValidUntil > DateTime.Now;

            return isValid && base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;

            if (request.IsAjaxRequest())
                response.SuppressFormsAuthenticationRedirect = true;

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}