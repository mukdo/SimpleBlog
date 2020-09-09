using Blog.Data;
using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Categories
{
    public class Category:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BlogComposes BlogComposes { get; set; }
    }
}
