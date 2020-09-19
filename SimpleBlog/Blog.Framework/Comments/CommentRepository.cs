using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Comments
{
    public class CommentRepository : Repository< Comment, int, FrameworkContext>, ICommentRepository
    {
        public CommentRepository(FrameworkContext frameworkContext) : base(frameworkContext)
        {

        }
    }
}
