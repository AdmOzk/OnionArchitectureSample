using OnionSample.Application.DTOs;

namespace OnionSample.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(int id);
    }
}
