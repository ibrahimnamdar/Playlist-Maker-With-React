using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Core;
using PlaylistMaker.Core.Models;
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
        
        [HttpGet("[action]")]
        public async Task<JsonResult> Login([FromQuery(Name = "code")] string code)
        {
            if (code!="undefined")
            {
                var token = await _repositoryAuth.GetToken(code);
                User user = await _repositoryAuth.GetUser(token);
            }
            var response =await _repositoryAuth.Redirect();
            return Json(response);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetUser([FromQuery(Name = "code")] string code)
        {
            User user = null;
            if (code != "undefined")
            {
                var token = await _repositoryAuth.GetToken(code);
                user = await _repositoryAuth.GetUser(token);
            }
            return Json(user);
        }
    }
}
