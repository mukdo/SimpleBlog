using Autofac;
using Blog.Data;
using Blog.membership.Contexts;
using Blog.membership.Data;
using Blog.membership.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Blog.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountSeed>()
                .InstancePerLifetimeScope();

            
            base.Load(builder);
        }
    }
}
