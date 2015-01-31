using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Ninject;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel m_kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            m_kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return m_kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return m_kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            m_kernel.Bind<Models.IValueCalculator>().To<Models.LinqValueCalculator>();
            m_kernel.Bind<Models.IDiscounter>().To<Models.DefaultDiscounter>().WithConstructorArgument("rate", 0.9M);
        }
    }
}