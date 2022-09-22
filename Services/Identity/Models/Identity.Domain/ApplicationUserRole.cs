using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}