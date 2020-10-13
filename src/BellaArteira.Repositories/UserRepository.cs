using BellaArteira.Core.Entities;
using BellaArteira.Core.Interfaces.Repositories;

using Dapper;
using Dapper.Contrib.Extensions;

using Npgsql;

using System;
using System.Data;
using System.Threading.Tasks;

namespace BellaArteira.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                var result = await _dbConnection.InsertAsync(user);
                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var result = await _dbConnection.GetAsync<User>(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<User> GetUserByLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
