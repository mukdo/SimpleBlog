using Blog.Framework.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Comments
{
    public class AddCommentModel : CommentBaseModel
    {
        [Required]
        public int BlogComposesId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsAprove { get; set; } = false;

        public AddCommentModel(ICommentService commentService) : base(commentService) { }
        public AddCommentModel() : base() { }
        public void Add()
        {
            var comment = new Comment()
            {   
                Name = this.Name,
                Email = this.Email,
                Message = this.Message,
                IsAprove = this.IsAprove,
                 BlogComposeId = this.BlogComposesId
            };
            _commentService.CreateComment(comment);
        }

    }
}
