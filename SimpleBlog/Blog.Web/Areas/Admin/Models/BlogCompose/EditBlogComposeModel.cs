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
    public class EditBlogComposeModel : BlogComposeBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryId { get; set; }

        public EditBlogComposeModel(IBlogComposeService  blogComposeService) : base(blogComposeService)
        {

        }
        public EditBlogComposeModel() : base()
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

        public void Edit()
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
                Id = this.Id,
                Title = this.Title,
                Body = this.Body,
                ImageUrl = fileName,
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