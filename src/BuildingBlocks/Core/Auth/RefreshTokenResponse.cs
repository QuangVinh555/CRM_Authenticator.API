using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auth
{
    public class RefreshTokenResponse
    {
        public string Token { get; set; }
        public DateTime? Expires { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
