using applicationdev.DbContextDirectory;
using applicationdev.ModelDirectory;
using Microsoft.EntityFrameworkCore;
namespace applicationdev.RepositoryDirectory;

public class TagRepository : ITagRepository
{
    private readonly JournalAppDbContext _dbContext;

    public TagRepository(JournalAppDbContext context)
    {
        _dbContext = context;
    }
    // ==================== CREATE ====================
    public async Task<Tag> AddTagAsync(Tag tag)
    {
        _dbContext.EntryTags.Add(tag);
        await _dbContext.SaveChangesAsync();
        return tag;
    }

    // ==================== READ ====================
    public async Task<Tag?> GetTagByIdAsync(int tagId)
    {
        return await _dbContext.EntryTags.FindAsync(tagId);
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _dbContext.EntryTags.ToListAsync();
    }


    // ==================== UPDATE ====================
    public async Task<bool> UpdateTagAsync(Tag tag)
    {
        var existing = await _dbContext.EntryTags.FindAsync(tag.TagKey);
        if (existing == null) return false;

        existing.TagTitle = tag.TagTitle;
        _dbContext.EntryTags.Update(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // ==================== DELETE ====================
    public async Task<bool> DeleteTagAsync(int tagId)
    {
        var existing = await _dbContext.EntryTags.FindAsync(tagId);
        if (existing == null) return false;

        _dbContext.EntryTags.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}