using Microsoft.AspNetCore.Mvc;
using api.Dtos.User;
using api.Models;
using Microsoft.AspNetCore.Identity;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Employee;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public struct LoginData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private readonly IAuthRepository _authRepo;
        public AuthController(ApplicationDBContext context, IAuthRepository AuthRepo)
        {
            _authRepo = AuthRepo;
        }

        [HttpPost]
        public async Task<object> GetToken([FromBody] LoginData ld)
        {

            var User = await _authRepo.GetFromLoginAndPassword(ld.Username, ld.Password);
            if (User == null)
            {
                return Unauthorized("Login or password is incorrect");
            }

            var Identity = AuthOptions.GetIdentity(User.Login, User.Password, User);
            if (Identity == null)
            {
                return Unauthorized(); // Неверные учетные данные
            }

            // Генерируем токен
            var Token = AuthOptions.GenerateToken(User.IsAdmin);

            return Ok(Token); // Возвращаем токен
        }
    }
}
