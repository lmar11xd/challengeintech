using InTech.Core.Entities;
using InTech.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTech.Core.Repositories.Query
{
    public interface IProductQueryRepository : IQueryRepository<Product>
    {
        //Operaciones no genéricas
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Int64 id);
        Task<Product> GetProductByName(string name);
    }
}
