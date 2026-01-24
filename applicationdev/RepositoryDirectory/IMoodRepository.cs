using applicationdev.ModelDirectory;

namespace applicationdev.RepositoryDirectory;

public interface IMoodRepository
{
    Task<Mood> AddMoodAsync(Mood mood);
    Task<Mood?> GetMoodByIdAsync(int moodId);
    Task<List<Mood>> GetAllMoodsAsync();

    Task<bool> UpdateMoodAsync(Mood mood);
    Task<bool> DeleteMoodAsync(int moodId);
}