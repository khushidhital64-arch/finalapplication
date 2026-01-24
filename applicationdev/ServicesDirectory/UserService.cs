using applicationdev.ModelDirectory;
using applicationdev.RepositoryDirectory;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<User> RegisterUserAsync(User user)
    {
        return await _userRepo.RegisterUserAsync(user);
    }

    public async Task<User?> LoginAsync(string usernameOrEmail, string password)
    {
        return await _userRepo.LoginAsync(usernameOrEmail, password);
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _userRepo.IsEmailTakenAsync(email);
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _userRepo.GetUserByIdAsync(userId);
    }

    public async Task<bool> UpdatePasswordAsync(int userId, string newPassword)
    {
        return await _userRepo.UpdatePasswordAsync(userId, newPassword);
    }
}