using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.BlogCompose
{
    public class BlogComposeModel : BlogComposeBaseModel
    {
        public BlogComposeModel(IBlogComposeService blogComposeService): base(blogComposeService)
        {

        }

        public BlogComposeModel() : base()
        {

        }

        internal object GetBlogCompose(DataTablesAjaxRequestModel dataTables)
        {
            var data = _blogComposeService.GetComposes(
                                   dataTables.PageIndex,
                                   dataTables.PageSize,
                                   dataTables.SearchText,
                                   dataTables.GetSortText(new string[] { "Title", "Body","CategoryId","ImageUrl","Date" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.composes
                        select new string[]
                        {
                                record.Title,
                                record.Body,
                                record.CategoryId.ToString(),
                                record.ImageUrl,
                                record.Date.ToString("dd/mm/yyyy"),
                                record.Id.ToString()
                        }
                   ).ToArray()

            };
        }

        internal string Delete(int Id)
        {
            var deleteBlogCompose = _blogComposeService.DeleteCompose(Id);
            return deleteBlogCompose.Title;

        }
    }
}
