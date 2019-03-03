using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using PlaylistMaker.Core;
using PlaylistMaker.Core.Models;
using PlaylistMaker.Persistence;

namespace PlaylistMaker.Helpers
{
    public class TokenValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            Response<List<Dictionary<string, object>>> response = new Response<List<Dictionary<string, object>>>();

            actionContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
            if (token.ToString() == "null" || string.IsNullOrEmpty(token.ToString()))
            {
                response.data = null;
                response.errorInfo = "Invalid token.";
                response.isSuccess = false;
                actionContext.HttpContext.Response.StatusCode = 401;
                actionContext.Result = new JsonResult(response);
            }
        }
    }
}
