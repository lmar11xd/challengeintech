using Dapper;
using Microsoft.Extensions.Configuration;
using InTech.Core.Entities;
using InTech.Core.Repositories.Query;
using InTech.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTech.Infrastructure.Repositories.Query
{
    public class ProductQueryRepository : QueryRepository<Product>, IProductQueryRepository
    {
        public ProductQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM PRODUCTS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Product>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM PRODUCTS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Product>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> GetProductByName(string name)
        {
            try
            {
                var query = "SELECT * FROM PRODUCTS WHERE Name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("Name", name, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Product>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
