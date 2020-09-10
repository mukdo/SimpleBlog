using Blog.Data;
using Blog.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blog.Framework.BlogCompose
{
    public class BlogComposes : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; } 
        public int CategoryId { get; set; }
        public ICollection<Category> Category { get; set; }
    }
}
