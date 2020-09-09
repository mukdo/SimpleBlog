using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.membership.Entities
{
    public class ApplicationUserRole
      : IdentityUserRole<Guid>
    {
        public ApplicationUser User { get; set; }
        public Role Role { get; set; }
    }
}
