using applicationdev.ModelDirectory;

namespace applicationdev.RepositoryDirectory;

public interface ITagRepository
{
    Task<Tag> AddTagAsync(Tag tag);
    Task<Tag?> GetTagByIdAsync(int tagId);
    Task<List<Tag>> GetAllTagsAsync();

    Task<bool> UpdateTagAsync(Tag tag);
    Task<bool> DeleteTagAsync(int tagId);
}