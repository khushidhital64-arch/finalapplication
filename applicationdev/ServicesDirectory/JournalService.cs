using applicationdev.ModelDirectory;
using applicationdev.RepositoryDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public class JournalService : IJournalService
{
    private readonly IJournalRepository _journalRepo;

    public JournalService(IJournalRepository journalRepo)
    {
        _journalRepo = journalRepo;
    }

    public async Task<JournalEntry> AddJournalAsync(JournalEntry entry)
    {
        return await _journalRepo.AddJournalAsync(entry);
    }

    public async Task<JournalEntry?> GetJournalByIdAsync(int journalId)
    {
        return await _journalRepo.GetJournalByIdAsync(journalId);
    }

    public async Task<List<JournalEntry>> GetAllJournalsAsync()
    {
        return await _journalRepo.GetAllJournalsAsync();
    }

    public async Task<bool> UpdateJournalAsync(JournalEntry entry)
    {
        return await _journalRepo.UpdateJournalAsync(entry);
    }

    public async Task<bool> DeleteJournalAsync(int journalId)
    {
        return await _journalRepo.DeleteJournalAsync(journalId);
    }
}