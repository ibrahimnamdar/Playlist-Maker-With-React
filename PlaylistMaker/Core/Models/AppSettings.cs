using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistMaker.Core.Models
{
    public class AppSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string BaseUrl { get; set; }

        public string RootSite { get; set; }

        public string AccountBaseUrl { get; set; }
    }
}
