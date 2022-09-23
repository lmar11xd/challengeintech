using InTech.Core.Entities;
using InTech.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InTech.Core.Repositories.Query
{
    public interface IUserQueryRepository : IQueryRepository<User>
    {
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<User> GetByIdAsync(Int64 id);
        Task<User> GetByUsername(string name);
    }
}
