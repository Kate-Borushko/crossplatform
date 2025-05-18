using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDBContext _context;
        public AuthRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User?> GetFromLoginAndPassword(string Usrname, string Passwrd)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == Usrname && u.Password == Passwrd);
        }
    }
}
