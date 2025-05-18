using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Helpers;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User UserModel)
        {
            await _context.Users.AddAsync(UserModel);
            await _context.SaveChangesAsync();

            return UserModel;
        }

        public async Task<User?> DeleteAsync(int Id)
        {
            var UserModel = await _context.Users.FirstOrDefaultAsync(x => x.UserID == Id);

            if (UserModel == null)
            {
                return null;
            }

            _context.Users.Remove(UserModel);
            await _context.SaveChangesAsync();

            return UserModel;
        }

        public async Task<List<User>> GetAllAsync(QueryObjectForUser query)
        {
            var Users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Role))
            {
                Users = Users.Where(u => u.Role.Contains(query.Role));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Surname", StringComparison.OrdinalIgnoreCase))
                {
                    Users = query.IsDecsending ? Users.OrderByDescending(u => u.Surname) : Users.OrderBy(u => u.Surname);
                }
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    Users = query.IsDecsending ? Users.OrderByDescending(u => u.UserID) : Users.OrderBy(u => u.UserID);
                }
            }

            return await Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User?> UpdateAsync(int Id, User UserModel)
        {
            var ExistingUser = await _context.Users.FindAsync(Id);

            if (ExistingUser == null)
            {
                return null;
            }

            ExistingUser.Name = UserModel.Name;
            ExistingUser.Surname = UserModel.Surname;
            ExistingUser.Email = UserModel.Email;
            //ExistingUser.Role = UserModel.Role;
            ExistingUser.Position = UserModel.Position;

            await _context.SaveChangesAsync();

            return ExistingUser;
        }
    }
}
