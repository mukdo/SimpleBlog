using Blog.Data;
using Blog.Framework.BlogCompose;
using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework
{
    public interface IBlogUnitOfWork:IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IBlogComposeRepository BlogRepository { get; set; }
    }
}
