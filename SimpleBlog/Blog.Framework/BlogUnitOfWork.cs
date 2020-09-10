using Blog.Data;
using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public BlogUnitOfWork( FrameworkContext frameworkContext ,ICategoryRepository categoryRepository)
            :base(frameworkContext)
        {
            CategoryRepository = categoryRepository;
        }
    }
}
