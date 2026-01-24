using applicationdev.ModelDirectory;
using applicationdev.RepositoryDirectory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace applicationdev.ServicesDirectory;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepo;

    public TagService(ITagRepository tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<Tag> AddTagAsync(Tag tag)
    {
        return await _tagRepo.AddTagAsync(tag);
    }

    public async Task<Tag?> GetTagByIdAsync(int tagId)
    {
        return await _tagRepo.GetTagByIdAsync(tagId);
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _tagRepo.GetAllTagsAsync();
    }

    public async Task<bool> UpdateTagAsync(Tag tag)
    {
        return await _tagRepo.UpdateTagAsync(tag);
    }

    public async Task<bool> DeleteTagAsync(int tagId)
    {
        return await _tagRepo.DeleteTagAsync(tagId);
    }
}