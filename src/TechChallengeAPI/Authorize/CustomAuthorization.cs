using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorization : Attribute, IAuthorizationFilter
    {
        public bool CheckAction { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                context.HttpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues token);

                if (!token.Any())
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var tokenString = token.ToString().Split(" ")[1];

                var authService = (IAuthService)context.HttpContext.RequestServices.GetService(typeof(IAuthService));
                if (!authService.ValidateToken(tokenString))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var username = authService.GetClaimsPrincipal(tokenString).Item1.Identity.Name ?? string.Empty;

                var userRoleService = (IUserRoleService)context.HttpContext.RequestServices.GetService(typeof(IUserRoleService));
                var role = userRoleService.GetRoleByUsername(username).Result;

                var route = context.RouteData.Values["controller"].ToString();
                if (CheckAction)
                {
                    route += "/" + context.RouteData.Values["action"].ToString();
                }

                var roleAccessService = (IRoleAccessService)context.HttpContext.RequestServices.GetService(typeof(IRoleAccessService));
                var hasAccess = roleAccessService.HasAccess(role.Id, route);

                if (!hasAccess)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
