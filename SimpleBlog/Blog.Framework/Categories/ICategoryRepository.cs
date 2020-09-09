using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Categories
{
    public interface ICategoryRepository : IRepository<Category, int, FrameworkContext>
    {
    }
}
