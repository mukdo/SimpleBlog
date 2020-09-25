using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.BlogCompose
{
    public class BlogComposeRepository : Repository<BlogComposes, int, FrameworkContext>, IBlogComposeRepository
    {
        public BlogComposeRepository(FrameworkContext frameworkContext) : base(frameworkContext)
        {

        }
    }
}