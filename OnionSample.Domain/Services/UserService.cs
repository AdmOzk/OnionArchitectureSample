using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionSample.Domain.Entities;
using OnionSample.Domain.Interfaces;

namespace OnionSample.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Tüm kullanıcıları getirir
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Belirli bir kullanıcıyı ID'ye göre getirir
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // Yeni kullanıcı ekler
        public async Task AddUserAsync(User user)
        {
            if (!ValidateUser(user))
                throw new ArgumentException("Invalid user data.");

            await _userRepository.AddAsync(user);
        }

        // Mevcut kullanıcıyı günceller
        public async Task UpdateUserAsync(User user)
        {
            if (!ValidateUser(user))
                throw new ArgumentException("Invalid user data.");

            await _userRepository.UpdateAsync(user);
        }

        // Belirli bir kullanıcıyı siler
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        // Kullanıcı için basit doğrulama kuralları (zorunlu alanlar)
        private bool ValidateUser(User user)
        {
            if (user == null)
                return false;

            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.EmailAddress))
                return false;

            return true;
        }
    }
}
