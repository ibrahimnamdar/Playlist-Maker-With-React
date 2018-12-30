using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaylistMaker.Core.Models;

namespace PlaylistMaker.Core
{
    public interface IAuthenticationRepository
    {
        Task<string> Redirect();
        Task<string> GetToken(string code);
        Task<User> GetUser(string token);
    }
}
