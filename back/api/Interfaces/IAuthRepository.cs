using api.Dtos.Employee;
using api.Models;

namespace api.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetFromLoginAndPassword(string Usrname, string Passwrd);
    }
}
