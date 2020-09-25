using Autofac;
using Blog.membership.Entities;
using Blog.Web.Areas.Admin.Models.BlogCompose;
using Blog.Web.Areas.Admin.Models.Categories;
using Blog.Web.Areas.Admin.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryModel>();
            builder.RegisterType<BlogComposeModel>();
            builder.RegisterType<CommentModel>();
           
            base.Load(builder);
        }
    }
}

