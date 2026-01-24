using applicationdev.DbContextDirectory;
using applicationdev.ModelDirectory;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.RepositoryDirectory;

public class JournalRepository : IJournalRepository
{
    private readonly JournalAppDbContext _dbContext;

    public JournalRepository(JournalAppDbContext context)
    {
        _dbContext = context;
    }

    // ==================== CREATE ====================
    public async Task<JournalEntry> AddJournalAsync(JournalEntry entry)
    {
        _dbContext.Entries.Add(entry);
        await _dbContext.SaveChangesAsync();
        return entry;
    }

    // ==================== READ ====================
    public async Task<JournalEntry?> GetJournalByIdAsync(int journalId)
    {
        return await _dbContext.Entries.FindAsync(journalId);
    }

    public async Task<List<JournalEntry>> GetAllJournalsAsync()
    {
        return await _dbContext.Entries
            // Primary tags
            .Include(j => j.EntryTags)
            .ThenInclude(et => et.RelatedTag)
            // Primary mood
            .Include(j => j.MainMood)
            // Secondary moods
            .Include(j => j.ExtraMoods)
            .ThenInclude(em => em.RelatedMood)

            .ToListAsync();
    }

    // ==================== UPDATE ====================
    public async Task<bool> UpdateJournalAsync(JournalEntry entry)
    {
        var existing = await _dbContext.Entries.FindAsync(entry.JournalId);
        if (existing == null) return false;

        // Update properties with new property names
        existing.JournalDate = entry.JournalDate;
        existing.BodyText = entry.BodyText;
        existing.TotalWordCount = entry.TotalWordCount;
        existing.MainMoodId = entry.MainMoodId;
        existing.OwnerId = entry.OwnerId;

        // For simplicity, secondary moods and tags can be handled later

        _dbContext.Entries.Update(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // ==================== DELETE ====================
    public async Task<bool> DeleteJournalAsync(int journalId)
    {
        var existing = await _dbContext.Entries.FindAsync(journalId);
        if (existing == null) return false;

        _dbContext.Entries.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
