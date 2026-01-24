using applicationdev.DbContextDirectory;
using applicationdev.ModelDirectory;
using Microsoft.EntityFrameworkCore;

namespace applicationdev.RepositoryDirectory;

public class MoodRepository : IMoodRepository
{
    private readonly JournalAppDbContext _dbContext;

    public MoodRepository(JournalAppDbContext context)
    {
        _dbContext = context;
    }

    
    // ==================== CREATE ====================
    public async Task<Mood> AddMoodAsync(Mood mood)
    {
        _dbContext.EntryMoods.Add(mood);
        await _dbContext.SaveChangesAsync();
        return mood;
    }

    // ==================== READ ====================
    public async Task<Mood?> GetMoodByIdAsync(int moodId)
    {
        return await _dbContext.EntryMoods.FindAsync(moodId);
    }

    public async Task<List<Mood>> GetAllMoodsAsync()
    {
        return await _dbContext.EntryMoods.ToListAsync();
    }


    // ==================== UPDATE ====================
    public async Task<bool> UpdateMoodAsync(Mood mood)
    {
        var existing = await _dbContext.EntryMoods.FindAsync(mood.MoodKey);
        if (existing == null) return false;

        existing.MoodTitle = mood.MoodTitle;
        existing.Category = mood.Category;
        _dbContext.EntryMoods.Update(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // ==================== DELETE ====================
    public async Task<bool> DeleteMoodAsync(int moodId)
    {
        var existing = await _dbContext.EntryMoods.FindAsync(moodId);
        if (existing == null) return false;

        _dbContext.EntryMoods.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}