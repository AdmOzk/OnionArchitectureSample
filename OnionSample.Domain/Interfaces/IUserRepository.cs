using OnionSample.Domain.Entities;
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
        Task<User> GetUserByEmailAsync(string email);
    }
}
