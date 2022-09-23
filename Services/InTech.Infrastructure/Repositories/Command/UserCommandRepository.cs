using Dapper;
using InTech.Core.Entities;
using InTech.Core.Repositories.Command;
using InTech.Infrastructure.Repositories.Command.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace InTech.Infrastructure.Repositories.Command
{
    public class UserCommandRepository : CommandRepository<User>, IUserCommandRepository
    {
        public UserCommandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Int64> AddAsync(User entity)
        {
            var sql = "INSERT INTO Users (Username,PasswordHash,PasswordSalt,CreatedDate,ModifiedDate) OUTPUT INSERTED.[Id] VALUES (@Username,@PasswordHash,@PasswordSalt,@CreatedDate,@ModifiedDate)";
            using (var connection = CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Int64>(sql, entity);
                return id;
            }
        }
        public async Task DeleteAsync(Int64 id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
        public async Task UpdateAsync(User entity)
        {
            var sql = "UPDATE Users SET Username = @Username, ModifiedDate = @ModifiedDate WHERE Id = @Id";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, entity);
            }
        }
    }
}
