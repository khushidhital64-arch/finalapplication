namespace applicationdev.ServicesDirectory;

public interface IStoreUserService
{
    int UserId { get; set; }
    string Username { get; set; }
    bool IsLoggedIn { get; }
    void SetUser(int userId, string username);
    void ClearUser();
}