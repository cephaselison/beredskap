using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.DTOs.AuthDTOs
{
    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Tenant { get; set; }
    }
}
