using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using EComponent.Services.Repositories;
using EComponent.DataAccess;
using EComponent.DataAccess.RepositoryImplementations;

namespace EComponent.Api.Registries
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IDbConnectionProvider>()
                .Use<DbConnectionProvider>()
                .Ctor<string>("connectionName")
                .Is("eComponentDbConnection"); ;
        }
    }
}