using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Categories
{
    public class CategoryModel : CategoryBaseModel
    {
        public CategoryModel( ICategoryService categoryService)  : base ( categoryService) { }
        public CategoryModel()  : base () { }

        internal object GetCategory(DataTablesAjaxRequestModel dataTables)
        {
            var data = _categoryService.GetCategories(
                                    dataTables.PageIndex,
                                    dataTables.PageSize,
                                    dataTables.SearchText,
                                    dataTables.GetSortText(new string[] { "Id", "Name" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.categories
                        select new string[]
                        {
                                record.Name,
                                record.Id.ToString()
                        }
                   ).ToArray()

            };
        }
        internal string Delete (int Id)
        {
            var deleteCategory = _categoryService.DeleteCategory(Id);
            return deleteCategory.Name;

        }
        
    }
        
    
}
