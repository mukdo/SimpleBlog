using Blog.Data;
using Blog.Framework.BlogCompose;
using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IBlogComposeRepository BlogRepository { get; set; }

        public BlogUnitOfWork( FrameworkContext frameworkContext ,ICategoryRepository categoryRepository, 
                                                                  IBlogComposeRepository composeRepository)
            :base(frameworkContext)
        {
            CategoryRepository = categoryRepository;
            BlogRepository = composeRepository;
        }
    }
}
