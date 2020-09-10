using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.BlogCompose
{
    public class EditBlogComposeModel : BlogComposeBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryId { get; set; }

        public EditBlogComposeModel(IBlogComposeService blogComposeService) : base(blogComposeService)
        {

        }
        public EditBlogComposeModel() : base()
        {

        }

        public void Edit()
        {
            var blogCompose = new BlogComposes()
            {
                Id = this.Id,
                Title = this.Title,
                Body = this.Body,
                ImageUrl = this.ImageUrl,
                Date = DateTime.Now,
                CategoryId = this.CategoryId
            };

            _blogComposeService.EditCompose(blogCompose);
        }

        internal void Load( int id)
        {
            var blogCompose = _blogComposeService.GetCompose(id);

            if(blogCompose != null)
            {
                Id = blogCompose.Id;
                Title = blogCompose.Title;
                Body = blogCompose.Body;
                ImageUrl = blogCompose.ImageUrl;
                DateTime = blogCompose.Date;
                CategoryId = blogCompose.CategoryId;
            }
        }
    }
}