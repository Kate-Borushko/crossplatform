using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(QueryObjectForUser query);
        Task<User?> GetByIdAsync(int Id);
        Task<User> CreateAsync(User UserModel);
        Task<User?> UpdateAsync(int Id, User UserModel);
        Task<User?> DeleteAsync(int Id);
    }
}
