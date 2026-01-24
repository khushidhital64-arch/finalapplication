using applicationdev.ModelDirectory;
using applicationdev.RepositoryDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public class MoodService : IMoodService
{
    private readonly IMoodRepository _moodRepo;

    public MoodService(IMoodRepository moodRepo)
    {
        _moodRepo = moodRepo;
    }

    public async Task<Mood> AddMoodAsync(Mood mood)
    {
        return await _moodRepo.AddMoodAsync(mood);
    }

    public async Task<Mood?> GetMoodByIdAsync(int moodId)
    {
        return await _moodRepo.GetMoodByIdAsync(moodId);
    }

    public async Task<List<Mood>> GetAllMoodsAsync()
    {
        return await _moodRepo.GetAllMoodsAsync();
    }

    public async Task<bool> UpdateMoodAsync(Mood mood)
    {
        return await _moodRepo.UpdateMoodAsync(mood);
    }

    public async Task<bool> DeleteMoodAsync(int moodId)
    {
        return await _moodRepo.DeleteMoodAsync(moodId);
    }
}