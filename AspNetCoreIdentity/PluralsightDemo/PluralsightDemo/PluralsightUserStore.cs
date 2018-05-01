using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PluralsightDemo
{
    public class PluralsightUserStore : IUserStore<PluralsightUser>
    {
        public async Task<IdentityResult> CreateAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            using(var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "insert into PluralsightUsers([Id]," +
                    "[UserName]," +
                    "[NormalizedUserName]," +
                    "[PasswordHash])" +
                    "values (@id, @userName, @normalizedUserName, @passwordHash);",
                    new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        normalizedUserName = user.NormalizedUserName,
                        passwordHash = user.PasswordHash
                    }
                );
            }

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ;
        }

        public async Task<PluralsightUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<PluralsightUser>("select * from PluralsightUsers where [Id] = @id", new {id = userId});
            }
        }

        public Task<PluralsightUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(PluralsightUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(PluralsightUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        
        }

        public async Task<IdentityResult> UpdateAsync(PluralsightUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "update PluralsightUsers" +
                    "set [UserName] = @userName," +
                    "    [NormalizedUserName] = @normalizedUserName," +
                    "    [PasswordHash] = @passwordHash" +
                    "where [Id] = @id;",
                    new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        normalizedUserName = user.NormalizedUserName,
                        passwordHash = user.PasswordHash
                    }
                );
            }

            return IdentityResult.Success;
        }

        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection("Data Source = (LocalDb)\\MSSQLLocalDB;" +
                "database=PluralsightDemo;Trusted_Connection=Yes;");
            connection.Open();
            return connection;
        }
    }
}
