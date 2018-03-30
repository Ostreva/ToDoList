using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
using Ninject;

namespace ToDoList.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //TODO: Add bindings
            kernel.Bind<ITaskManagerRepository>().To<EFTaskManagerRepository>();
        }
    }
}