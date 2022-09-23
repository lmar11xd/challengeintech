using Dapper;
using InTech.Core.Entities;
using InTech.Core.Repositories.Query;
using InTech.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InTech.Infrastructure.Repositories.Query
{
    public class UserQueryRepository : QueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Users";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<User>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<User> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM Users WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<User>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                var query = "SELECT * FROM Users WHERE Username = @username";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<User>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
