using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistMaker.Core.Models
{
    public class Response<T>
    {
        public bool isSuccess { get; set; }

        public T data { get; set; }

        public string errorInfo { get; set; }
    }
}
