using Microsoft.Extensions.Configuration;
using InTech.Core.Repositories.Command.Base;
using InTech.Infrastructure.Data;

namespace InTech.Infrastructure.Repositories.Command.Base
{
    public class CommandRepository<T> : DbConnector, ICommandRepository<T> where T : class
    {
        public CommandRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
