using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlaylistMaker.Core;
using PlaylistMaker.Core.Models;
using PlaylistMaker.SpotifyHelpers;
using RestSharp;
using RestSharp.Extensions;

namespace PlaylistMaker.Persistence
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private AppSettings AppSettings { get; set; }
        private IRestClient Client { get; set; }

        public AuthenticationRepository(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
            Client = new RestClient(AppSettings.AccountBaseUrl);
        }
        public async Task<string> Redirect()
        {
            var redirectUrl = $"{AppSettings.AccountBaseUrl}/authorize?client_id={AppSettings.ClientId}&redirect_uri=https://localhost:44320/user&response_type=code&scope=user-read-private user-read-email";
            
            return redirectUrl;
        }

        public async Task<string> GetToken(string code)
        {
            var request = new RestRequest("/api/token", Method.POST);
            var base64 = SpotifyHelper.Base64Encode($"{AppSettings.ClientId}:{AppSettings.ClientSecret}");

            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", "https://localhost:44320/user");
            request.AddParameter("grant_type", "authorization_code");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {base64}");
            IRestResponse response = await Client.ExecutePostTaskAsync<AccessTokenResponse>(request);

            return JsonConvert.DeserializeObject<AccessTokenResponse>(response?.Content)?.AccessToken;
        }

        public async Task<User> GetUser(string token)
        {
            var client = new RestClient(AppSettings.BaseUrl);
            var request = new RestRequest("/v1/me", Method.GET);

            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var response = await client.ExecuteGetTaskAsync<User>(request);

            var user = JsonConvert.DeserializeObject<User>(response.Content);

            return user;
        }
    }
}
