using Dapper;
using Microsoft.Extensions.Configuration;
using InTech.Core.Entities;
using InTech.Core.Repositories.Command;
using InTech.Infrastructure.Repositories.Command.Base;
using System;
using System.Threading.Tasks;

namespace InTech.Infrastructure.Repositories.Command
{
    public class ProductCommandRepository : CommandRepository<Product>, IProductCommandRepository
    {
        public ProductCommandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Int64> AddAsync(Product entity)
        {
            var sql = "INSERT INTO Products (Name,Price,CreatedDate,ModifiedDate) OUTPUT INSERTED.[Id] VALUES (@Name,@Price,@CreatedDate,@ModifiedDate)";
            using (var connection = CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Int64>(sql, entity);
                return id;
            }
        }
        public async Task DeleteAsync(Int64 id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
        public async Task UpdateAsync(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price, ModifiedDate = @ModifiedDate WHERE Id = @Id";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, entity);
            }
        }
    }
}
