using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlaylistMaker.Core;
using PlaylistMaker.Core.Models;
using PlaylistMaker.SpotifyHelpers;
using RestSharp;

namespace PlaylistMaker.Persistence
{
    public class SpotifyRepository : ISpotifyRepository
    {
        private AppSettings AppSettings { get; set; }
        private IRestClient Client { get; set; }

        public SpotifyRepository(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
            Client = new RestClient(AppSettings.BaseUrl);
        }

        

    }
}
