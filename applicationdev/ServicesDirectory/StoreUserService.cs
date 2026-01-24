namespace applicationdev.ServicesDirectory;

public class StoreUserService : IStoreUserService
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;

    public bool IsLoggedIn => UserId > 0;

    public void SetUser(int userId, string username)
    {
        UserId = userId;
        Username = username;
    }

    public void ClearUser()
    {
        UserId = 0;
        Username = string.Empty;
    }

}