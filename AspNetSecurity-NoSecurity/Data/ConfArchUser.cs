using Microsoft.AspNetCore.Identity;
using System;

namespace AspNetSecurityNoSecurity.Data
{
    public class ConfArchUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }
}
