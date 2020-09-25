using Autofac;
using Blog.Framework.BlogCompose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models.BlogCompose
{
    public class BlogComposeBaseModel : AdminBaseModel, IDisposable
    {
        protected IBlogComposeService  _blogComposeService;
        public BlogComposeBaseModel( IBlogComposeService  blogComposeService)
        {
            _blogComposeService = blogComposeService;
        }

        public BlogComposeBaseModel()
        {
            _blogComposeService = Startup.AutofacContainer.Resolve<IBlogComposeService >();
        }

        public void Dispose()
        {
            _blogComposeService?.Dispose();
        }
    }
}
