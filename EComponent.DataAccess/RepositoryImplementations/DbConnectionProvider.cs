using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComponent.Services.Repositories;

namespace EComponent.DataAccess.RepositoryImplementations
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly string _connectionName;
        public DbConnectionProvider(string connectionName)
        {
            _connectionName = connectionName;
        }

        public string GetConnectionName()
        {
            return _connectionName;
        }

        public string GetConnectionString()
        {
            string conStr = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
            return conStr;
        }
    }
}
