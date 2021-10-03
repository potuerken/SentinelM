using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.Helpers
{
    public class AccessToken
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
