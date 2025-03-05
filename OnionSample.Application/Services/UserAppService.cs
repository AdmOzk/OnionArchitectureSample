using AutoMapper;
using OnionSample.Application.DTOs;
using OnionSample.Application.Interfaces;
using OnionSample.Domain.Entities;
using OnionSample.Domain.Interfaces;
using OnionSample.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _domainUserService;
        private readonly IMapper _mapper;
        public UserAppService(IUserService domainUserService, IMapper mapper)
        {
            _domainUserService = domainUserService;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            // Map DTO to Domain entity.
            var user = _mapper.Map<User>(userDto);
            var created = await _domainUserService.CreateAsync(user);
            return _mapper.Map<UserDto>(created);
        }
        public async Task DeleteAsync(int id)
        {
            await _domainUserService.DeleteAsync(id);
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _domainUserService.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _domainUserService.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task UpdateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _domainUserService.UpdateAsync(user);
        }
    }
}
