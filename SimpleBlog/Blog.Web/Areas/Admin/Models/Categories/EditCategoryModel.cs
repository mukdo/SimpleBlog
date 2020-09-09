using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryModel : CategoryBaseModel
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public EditCategoryModel( ICategoryService categoryService) : base(categoryService)
        {

        }

        public EditCategoryModel() : base()
        {

        }

        public void Edit()
        {
            var category = new Category
            {
                Id = this.Id,
                Name = this.Name
            };

            _categoryService.EditCategory(category);
        }

        internal void Load(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }
    }
}
