using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Core;
using PlaylistMaker.Core.Models;
using PlaylistMaker.Helpers;
using RestSharp;
using RestSharp.Extensions;

namespace PlaylistMaker.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IAuthenticationRepository _repositoryAuth;
        private readonly ISpotifyRepository _repositorySpotify;

        public SampleDataController(IAuthenticationRepository repositoryAuth, ISpotifyRepository repositorySpotify)
        {
            _repositoryAuth = repositoryAuth;
            _repositorySpotify = repositorySpotify;
        }

        public string _currentUserToken
        {
            get
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                return !string.IsNullOrEmpty(token) ? token.ToString() : null;
            }
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> Login([FromQuery(Name = "code")] string code)
        {
            if (code != "undefined")
            {
                var token = await _repositoryAuth.GetToken(code);
                User user = await _repositoryAuth.GetUser(token);
            }
            var response = await _repositoryAuth.Redirect();
            return Json(response);
        }

        [HttpGet("[action]")]
        [TokenValidation]
        public async Task<JsonResult> GetUser()
        {
            User user = await _repositoryAuth.GetUser(_currentUserToken);
            return Json(user);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetToken([FromQuery(Name = "code")] string code)
        {
            var token = await _repositoryAuth.GetToken(code);

            return token != "undefined" ? Json(token) : Json("");
        }
    }
}
