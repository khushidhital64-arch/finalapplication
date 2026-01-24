using applicationdev.ModelDirectory;

namespace applicationdev.RepositoryDirectory;

public interface IJournalRepository
{
    Task<JournalEntry> AddJournalAsync(JournalEntry entry);
    Task<JournalEntry?> GetJournalByIdAsync(int entryId);
    Task<List<JournalEntry>> GetAllJournalsAsync();
    Task<bool> UpdateJournalAsync(JournalEntry entry);
    Task<bool> DeleteJournalAsync(int entryId);
    
}