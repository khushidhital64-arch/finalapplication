using applicationdev.ModelDirectory;

namespace applicationdev.RepositoryDirectory;

public interface IUserRepository
{
    // Register a new user
    Task<User> RegisterUserAsync(User user);

    // Login: check username/email and password
    Task<User?> LoginAsync(string usernameOrEmail, string password);
    

    // Check if email already exists
    Task<bool> IsEmailTakenAsync(string email);

    // Get user by Id
    Task<User?> GetUserByIdAsync(int userId);

    // Optional: update password
    Task<bool> UpdatePasswordAsync(int userId, string newPassword);
}