using Blog.Data;
using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Framework.Comments
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsAprove { get; set; }
        public int BlogComposeId { get; set; } 
        public BlogComposes BlogComposes { get; set; }
    }
}
