using InTech.Core.Entities;
using InTech.Core.Repositories.Command.Base;
using System;
using System.Threading.Tasks;

namespace InTech.Core.Repositories.Command
{
    public interface IProductCommandRepository: ICommandRepository<Product>
    {
        Task<Int64> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Int64 id);
    }
}
