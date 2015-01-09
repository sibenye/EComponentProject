using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace EComponent.Tools.StructureMap
{
    public class StructureMapServiceControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var scope = request.GetDependencyScope();
            return scope.GetService(controllerType) as IHttpController;
        }
    }
}
