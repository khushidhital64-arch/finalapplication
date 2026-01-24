using applicationdev.ModelDirectory;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public interface IUserService
{
    Task<User> RegisterUserAsync(User user);
    Task<User?> LoginAsync(string usernameOrEmail, string password);
    Task<bool> IsEmailTakenAsync(string email);
    Task<User?> GetUserByIdAsync(int userId);
    Task<bool> UpdatePasswordAsync(int userId, string newPassword);
}