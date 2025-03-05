using OnionSample.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(int id);
    }
}
