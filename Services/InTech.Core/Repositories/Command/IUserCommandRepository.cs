using InTech.Core.Entities;
using InTech.Core.Repositories.Command.Base;
using System;
using System.Threading.Tasks;

namespace InTech.Core.Repositories.Command
{
    public interface IUserCommandRepository : ICommandRepository<User>
    {
        Task<Int64> AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(Int64 id);
    }
}
