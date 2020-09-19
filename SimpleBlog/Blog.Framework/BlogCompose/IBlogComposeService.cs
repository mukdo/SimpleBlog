using Blog.Framework.Categories;
using Blog.Framework.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.BlogCompose
{
    public interface IBlogComposeService : IDisposable
    {

        (IList<BlogComposes> composes, int total, int totalDisplay) GetComposes(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateCompose(BlogComposes blogComposes);
        void EditCompose(BlogComposes blogComposes);
        BlogComposes GetCompose(int Id);
        BlogComposes DeleteCompose(int Id);
        IList<Category> GetCategory();
    }
}