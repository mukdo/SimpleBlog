using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.BlogCompose
{
    public interface IBlogComposeRepository : IRepository<BlogComposes, int, FrameworkContext>
    {
    }
}
