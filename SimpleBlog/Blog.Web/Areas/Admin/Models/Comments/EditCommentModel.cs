using Blog.Framework.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Comments
{
    public class EditCommentModel : CommentBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsAprove { get; set; }
        
        public int BlogcomposeId { get; set; }

        public EditCommentModel(ICommentService commentService) : base(commentService) { } 
        public EditCommentModel() : base() { }
        
        public void Edit()
        {
            var comment = new Comment()
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email,
                Message = this.Message,
                IsAprove = this.IsAprove
               // BlogComposes = this.BlogcomposeId.ToString()
            };
            _commentService.EditComment(comment);
        }

        internal void Load(int id)
        {
            var comment = _commentService.GetComment(id);

            if (comment != null)
            {
                Id = comment.Id;
                Name = comment.Name;
                Email = comment.Email;
                Message = comment.Message;
                IsAprove = comment.IsAprove;
                
            }
        }
    }
}
