namespace Sequin.Autofac.Sample
{
    using System;
    using Configuration;
    using global::Autofac;
    using global::Owin;
    using Owin;
    using Owin.Extensions;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ConfigureAutofac();

            app.UseSequin(SequinOptions.Configure()
                                       .WithOwinDefaults()
                                       .WithHandlerFactory(x => new AutofacHandlerFactory(container))
                                       .Build());
        }

        private static IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .Where(t => t.Name.EndsWith("Handler"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            var container = builder.Build();
            return container;
        }
    }
}