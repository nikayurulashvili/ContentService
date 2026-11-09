using Microsoft.EntityFrameworkCore;
using SocialNetwork.Content.Entities.Entities;
using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Interfaces;

namespace SocialNetwork.Content.Repositories.Repositories;

public class PostAudienceRepository
    : BaseRepository<PostAudience>, IPostAudienceRepository
{
    public PostAudienceRepository(ContentDbContext context)
        : base(context)
    {
    }

    public override Task<PostAudience?> GetByIdAsync(Guid id)
        => throw new NotSupportedException(
            "PostAudience has a composite key (PostId, UserId); use GetAudienceByPostIdAsync or the composite-key methods instead.");

    public async Task<List<PostAudience>> GetAudienceByPostIdAsync(Guid postId)
    {
        return await _dbSet
            .Where(pa => pa.PostId == postId)
            .ToListAsync();
    }

    public async Task<List<PostAudience>> GetPostsByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Where(pa => pa.UserId == userId)
            .ToListAsync();
    }

    public async Task RemoveAudienceByPostIdAsync(Guid postId)
    {
        var audience = await _dbSet
            .Where(pa => pa.PostId == postId)
            .ToListAsync();

        _dbSet.RemoveRange(audience);
    }
}