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
        private readonly IAuthenticationRepository repositoryAuth;
        private readonly ISpotifyRepository repositorySpotify;

        public SampleDataController(IAuthenticationRepository repositoryAuth, ISpotifyRepository repositorySpotify)
        {
            this.repositoryAuth = repositoryAuth;
            this.repositorySpotify = repositorySpotify;
        }
        
        [HttpGet("[action]")]
        public async Task<JsonResult> Login([FromQuery(Name = "code")] string code)
        {
            if (code!="undefined")
            {
                var token = await repositoryAuth.GetToken(code);
                User user = await repositoryAuth.GetUser(token);
            }
            var response =await repositoryAuth.Redirect();
            return Json(response);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetUser([FromQuery(Name = "code")] string code)
        {
            User user = null;
            if (code != "undefined")
            {
                var token = await repositoryAuth.GetToken(code);
                user = await repositoryAuth.GetUser(token);
            }
            return Json(user);
        }
    }
}
