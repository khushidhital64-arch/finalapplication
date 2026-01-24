using applicationdev.ModelDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public interface IMoodService
{
    Task<Mood> AddMoodAsync(Mood mood);
    Task<Mood?> GetMoodByIdAsync(int moodId);
    Task<List<Mood>> GetAllMoodsAsync();
    Task<bool> UpdateMoodAsync(Mood mood);
    Task<bool> DeleteMoodAsync(int moodId);
}