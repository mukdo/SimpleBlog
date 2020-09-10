﻿using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        public CreateBlogComposeModel(IBlogComposeService blogComposeService) : base(blogComposeService)
        {

        }

        public CreateBlogComposeModel() : base()
        {

        }

        public void Create()
        {
            var blogCompose = new BlogComposes()
            {
                Title = this.Title,
                Body = this.Body,
                ImageUrl = this.ImageUrl,
                Date =this.DateTime,
                CategoryId = this.CategoryId
            };

            _blogComposeService.CreateCompose(blogCompose);
        }
    }
}
