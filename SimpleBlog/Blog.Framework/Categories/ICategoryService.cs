using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Categories
{
    public interface ICategoryService:IDisposable
    {
        (IList<Category> categories, int total, int totalDisplay) GetCategories(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateCategory(Category category);
        void EditCategory(Category category);
        Category GetCategory(int Id);
        Category DeleteCategory(int Id);
    }
}
