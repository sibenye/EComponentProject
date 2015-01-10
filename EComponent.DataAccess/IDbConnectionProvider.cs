using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.DataAccess
{
    public interface IDbConnectionProvider
    {
        string GetConnectionName();

        string GetConnectionString();

        IDbConnection GetConnection();
    }
}
