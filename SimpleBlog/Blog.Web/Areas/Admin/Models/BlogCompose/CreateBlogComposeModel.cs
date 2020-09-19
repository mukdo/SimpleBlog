using Autofac;
using Blog.Framework.BlogCompose;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.BlogCompose
{
    public class CreateBlogComposeModel : BlogComposeBaseModel
    {
        [Required]
        [StringLength (500 , MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        public CreateBlogComposeModel(IBlogComposeService  blogComposeService) : base(blogComposeService)
        {

        }

        public CreateBlogComposeModel() : base()
        {

        }

        public IList<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _blogComposeService.GetCategory())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
        public void Create()
        {
            var hostingEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();

            string wwwRootpath = hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootpath + "/images/", fileName);

            var stream = new FileStream(path, FileMode.Create);
            ImageFile.CopyToAsync(stream);

            var blogCompose = new BlogComposes()
            {
                Title = this.Title,
                Body = this.Body,
                ImageUrl = fileName,
                Date =this.DateTime,
                CategoryId = this.CategoryId
            };

            _blogComposeService.CreateCompose(blogCompose);
        }
    }
}
