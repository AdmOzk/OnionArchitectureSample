using OnionSample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
