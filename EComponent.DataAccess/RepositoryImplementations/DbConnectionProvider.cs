using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
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
            return ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            string conStr = GetConnectionString();
            var dbConnection = new MySqlConnection(conStr);
            dbConnection.Open();
            return dbConnection;
        }
    }
}
