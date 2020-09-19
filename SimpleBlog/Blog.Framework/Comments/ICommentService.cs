using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Comments
{
    public interface ICommentService : IDisposable
    {
        (IList<Comment> comments, int total, int totalDisplay) GetComments(int pageindex,
                                                                                 int Pagesize,
                                                                                 string searchText,
                                                                                 string sortText);
        void CreateComment(Comment comment);
        void EditComment(Comment comment);
        Comment GetComment(int Id);
        Comment DeleteComment(int Id);
      
    }
}
