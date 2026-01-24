using applicationdev.ModelDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public interface ITagService
{
    Task<Tag> AddTagAsync(Tag tag);
    Task<Tag?> GetTagByIdAsync(int tagId);
    Task<List<Tag>> GetAllTagsAsync();
    Task<bool> UpdateTagAsync(Tag tag);
    Task<bool> DeleteTagAsync(int tagId);
}