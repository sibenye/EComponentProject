using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComponent.Services.Repositories;

namespace EComponent.DataAccess.RepositoryImplementations
{
    public class BaseRepository
    {
        protected readonly IDbConnectionProvider DbProvider;

        public BaseRepository(IDbConnectionProvider dbProvider)
        {
            DbProvider = dbProvider;
        }
    }
}
