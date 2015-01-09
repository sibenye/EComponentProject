using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Web.Http.Dependencies;
using System.Threading.Tasks;

namespace EComponent.Tools.StructureMap
{
    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Returns intance of StructureMapDependency 
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var child = this.Container.GetNestedContainer();
            return new StructureMapDependencyScope(child);
        }
    }
}
