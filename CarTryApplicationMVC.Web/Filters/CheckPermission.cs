using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarTryApplicationMVC.Web.Filters
{
    public class CheckPermission : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;
        public CheckPermission(string permission)
        {
            _permission = permission;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
           // bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
        }

        //private bool CheckUserPermission(ClaimsPrincipal user, string permission)
        //{

        //}
    }
}
