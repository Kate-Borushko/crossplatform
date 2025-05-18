using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Dtos.User;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static api.Mappers.UserMappers;
using api.Dtos.Employee;
using api.Helpers;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public UserController(IUserRepository UserRepo, IEmployeeRepository EmployeeRepo)
        {
            _userRepo = UserRepo;
            _employeeRepo = EmployeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectForUser Query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Users = await _userRepo.GetAllAsync(Query);
            var UserDTO = Users.Select(s => s.ToUserDto());

            return Ok(Users);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var User = await _userRepo.GetByIdAsync(Id);

            if (User == null)
            {
                return NotFound("User is not found");
            }

            return Ok(User.ToUserDto());
        }

        [HttpPost("{EmployeeId:int}")]
        public async Task<IActionResult> Create([FromRoute] int EmployeeId, CreateUserRequestDto UserRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _employeeRepo.EmployeeExists(EmployeeId))
            {
                return BadRequest("Employee does not exist");
            }

            var UserModel = UserRequestDto.ToUserFromCreateDTO(EmployeeId);
            await _userRepo.CreateAsync(UserModel);

            return CreatedAtAction(nameof(GetById), new { id = UserModel.UserID }, UserModel.ToUserDto());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateUserRequestDto UpdateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserModel = await _userRepo.UpdateAsync(Id, UpdateUserDto.ToUserFromUpdateDTO());

            if (UserModel == null)
            {
                return NotFound("User is not found");
            }

            return Ok(UserModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserModel = await _userRepo.DeleteAsync(Id);

            if (UserModel == null)
            {
                return NotFound("User is not found");
            }

            return NoContent();
        }

    }
}
