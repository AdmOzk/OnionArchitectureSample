using Microsoft.AspNetCore.Mvc;
using OnionSample.Application.DTOs;
using OnionSample.Application.Interfaces;
using System.Threading.Tasks;

namespace OnionSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userAppService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userAppService.GetAllAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            var created = await _userAppService.CreateAsync(userDto);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            await _userAppService.UpdateAsync(userDto);
            return Ok("User updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userAppService.DeleteAsync(id);
            return Ok("User deleted successfully.");
        }
    }
}
