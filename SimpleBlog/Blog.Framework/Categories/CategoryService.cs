using System.Collections.Generic;
using System.Linq;

namespace Blog.Framework.Categories
{
    public class CategoryService : ICategoryService
    {
        private IBlogUnitOfWork _blogUnitOfWork;

        public CategoryService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateCategory(Category category)
        {
            _blogUnitOfWork.CategoryRepository.Add(category);
            _blogUnitOfWork.Save();
        }

        public Category DeleteCategory(int Id)
        {
            var category = _blogUnitOfWork.CategoryRepository.GetById(Id);
            _blogUnitOfWork.CategoryRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return category;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditCategory(Category category)
        {
            var exitingCategory = _blogUnitOfWork.CategoryRepository.GetById(category.Id);
                exitingCategory.Name = category.Name;

            _blogUnitOfWork.Save();

        }

        public (IList<Category> categories, int total, int totalDisplay) GetCategories(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.CategoryRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public Category GetCategory(int Id)
        {
            return _blogUnitOfWork.CategoryRepository.GetById(Id);
        }
    }
}
