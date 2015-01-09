using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using StructureMap;
using StructureMap.Graph;
using EComponent.Tools.StructureMap;

namespace EComponent.Api
{
    public class StructureMapConfig
    {
        public static void Inititialize(HttpConfiguration config)
        {
            var container = new Container(c => c.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AssembliesFromApplicationBaseDirectory();
                scan.LookForRegistries();
                scan.WithDefaultConventions();
            }));

            config.DependencyResolver = new StructureMapDependencyResolver(container);
            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapServiceControllerActivator());
        }
    }
}