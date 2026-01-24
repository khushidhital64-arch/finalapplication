using applicationdev.ModelDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public interface IJournalService
{
    Task<JournalEntry> AddJournalAsync(JournalEntry entry);
    Task<JournalEntry?> GetJournalByIdAsync(int journalId);
    Task<List<JournalEntry>> GetAllJournalsAsync();
    Task<bool> UpdateJournalAsync(JournalEntry entry);
    Task<bool> DeleteJournalAsync(int journalId);
}