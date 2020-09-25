using Blog.Framework.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.Comments
{
    public class CommentModel : CommentBaseModel
    {
        public CommentModel(ICommentService commentService) : base(commentService)
        {

        }
        public CommentModel() : base()
        {

        }

        internal object GetComment(DataTablesAjaxRequestModel dataTables)
        {
            var data = _commentService.GetComments(
                                    dataTables.PageIndex,
                                    dataTables.PageSize,
                                    dataTables.SearchText,
                                    dataTables.GetSortText(new string[] { "Name" ,"Email","Message","Stutas" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.comments
                        select new string[]
                        {
                                record.Name,
                                record.Email,
                                record.Message,
                                record.IsAprove.ToString(),
                                record.Id.ToString()
                        }
                   ).ToArray()

            };
        }
        internal string Delete(int Id)
        {
            var deleteComment = _commentService.DeleteComment(Id);
            return deleteComment.Name;

        }
    }
}
