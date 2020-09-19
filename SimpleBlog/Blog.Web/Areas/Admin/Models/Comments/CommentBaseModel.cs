using Autofac;
using Blog.Framework.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Comments
{
    public class CommentBaseModel : AdminBaseModel, IDisposable
    {
        protected ICommentService _commentService;
        public CommentBaseModel( ICommentService commentService)
        {
            _commentService = commentService;
        }
        public CommentBaseModel()
        {
            _commentService = Startup.AutofacContainer.Resolve<ICommentService>();
        }
        public void Dispose()
        {
            _commentService?.Dispose();
        }
    }
}
