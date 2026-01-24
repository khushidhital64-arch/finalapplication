using applicationdev.DbContextDirectory;
using applicationdev.ModelDirectory;
using Microsoft.EntityFrameworkCore;

namespace applicationdev.RepositoryDirectory;

public class UserRepository : IUserRepository
{
    private readonly JournalAppDbContext _dbContext;

    public UserRepository(JournalAppDbContext context)
    {
        _dbContext = context;
    }

    // ==================== REGISTER ====================
    public async Task<User> RegisterUserAsync(User user)
    {
        _dbContext.AppUsers.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    // ==================== LOGIN ====================
    public async Task<User?> LoginAsync(string usernameOrEmail, string password)
    {
        return await _dbContext.AppUsers
            .FirstOrDefaultAsync(u =>
                (u.LoginId == usernameOrEmail || u.MailAddress == usernameOrEmail)
                && u.SecretHash == password);
    }

    // ==================== CHECK EMAIL ====================
    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _dbContext.AppUsers.AnyAsync(u => u.MailAddress == email);
    }

    // ==================== GET USER BY ID ====================
    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _dbContext.AppUsers.FindAsync(userId); // EF uses UserKey automatically
    }

    // ==================== UPDATE PASSWORD ====================
    public async Task<bool> UpdatePasswordAsync(int userId, string newPassword)
    {
        var user = await _dbContext.AppUsers.FindAsync(userId);
        if (user == null)
            return false;

        user.SecretHash = newPassword;  
        _dbContext.AppUsers.Update(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}