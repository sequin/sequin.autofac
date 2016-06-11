namespace Sequin.Autofac
{
    using System.Collections.Generic;
    using System.Linq;
    using global::Autofac;
    using Infrastructure;

    public class AutofacHandlerFactory : IHandlerFactory
    {
        private readonly IComponentContext context;

        public AutofacHandlerFactory(IComponentContext context)
        {
            this.context = context;
        }

        ICollection<IHandler<T>> IHandlerFactory.GetForCommand<T>()
        {
            return context.Resolve<IEnumerable<IHandler<T>>>().ToList();
        }
    }
}