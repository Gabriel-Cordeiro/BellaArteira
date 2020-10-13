using BellaArteira.Core.Entities;

using System.Threading.Tasks;

namespace BellaArteira.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);

        public Task<User> GetUserById(int id);

        public Task<User> GetUserByLogin(string email, string password);
    }
}
