using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.DataAccess
{
    public interface IDbConnectionProvider
    {
        string GetConnectionName();

        string GetConnectionString();
    }
}
