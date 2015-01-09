using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using System.Web.Http.Dependencies;

namespace EComponent.Tools.StructureMap
{
    public class StructureMapDependencyScope : ServiceLocatorImplBase, IDependencyScope
    {
        protected readonly IContainer Container;

        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapDependencyScope"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="container"/> is null.</exception>
        public StructureMapDependencyScope(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        ///        resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">
        /// Type of service requested.
        /// </param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType).Cast<object>();
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        ///        the requested service instance.
        /// </summary>
        /// <param name="serviceType">
        /// Type of instance requested.
        /// </param>
        /// <param name="key">
        /// Name of registered service you want. May be null.
        /// </param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                           ? this.Container.TryGetInstance(serviceType)
                           : this.Container.GetInstance(serviceType);
            }

            return this.Container.GetInstance(serviceType, key);
        }
    }
}
