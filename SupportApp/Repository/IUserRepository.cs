using SupportApp.Models;

namespace SupportApp.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUser();
    Task<string> CreateUser(User userDto);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}