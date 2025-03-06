using OnionSample.Domain.Entities;
using OnionSample.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }
        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
