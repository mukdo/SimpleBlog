using System;

using Microsoft.AspNetCore.Identity;

namespace Blog.membership.Entities
{
    public class UserLogin
        : IdentityUserLogin<Guid>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
