using Microsoft.EntityFrameworkCore;
using SocialNetwork.Content.Entities.Entities;
using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Interfaces;

namespace SocialNetwork.Content.Repositories.Repositories;

public class PostLikeRepository
    : BaseRepository<PostLike>, IPostLikeRepository
{
    public PostLikeRepository(ContentDbContext context)
        : base(context)
    {
    }

    public async Task<List<PostLike>> GetLikesByPostIdAsync(Guid postId)
    {
        return await _dbSet
            .Where(pl => pl.PostId == postId)
            .ToListAsync();
    }

    public async Task<bool> IsLikedByUserAsync(Guid postId, Guid userId)
    {
        return await _dbSet.AnyAsync(
            pl => pl.PostId == postId && pl.UserId == userId);
    }

    public async Task RemoveLikeAsync(Guid postId, Guid userId)
    {
        var like = await _dbSet.FirstOrDefaultAsync(
            pl => pl.PostId == postId && pl.UserId == userId);

        if (like is not null)
        {
            _dbSet.Remove(like);
        }
    }

    public async Task<int> GetLikesCountAsync(Guid postId)
    {
        return await _dbSet.CountAsync(pl => pl.PostId == postId);
    }
}