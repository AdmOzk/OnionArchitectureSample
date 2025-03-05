using OnionSample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        // Added method to get a user by email.
        Task<User> GetUserByEmailAsync(string email);
    }
}
