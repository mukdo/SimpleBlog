using Autofac;
using Blog.membership.Contexts;
using System;

namespace Blog.Framework
{
    public class ContextModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ContextModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            

            //builder.RegisterType<CustomerService>().As<ICustomerService>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
