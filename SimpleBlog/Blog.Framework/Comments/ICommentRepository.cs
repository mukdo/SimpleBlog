using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Comments
{
    public interface ICommentRepository : IRepository< Comment, int, FrameworkContext >
    {
    }
}
