using Microsoft.Extensions.Configuration;
using InTech.Core.Repositories.Query.Base;
using InTech.Infrastructure.Data;

namespace InTech.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
