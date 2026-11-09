using Microsoft.EntityFrameworkCore;
using SocialNetwork.Content.Entities.Entities;

using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Interfaces;

namespace SocialNetwork.Content.Repositories.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(ContentDbContext context)
        : base(context)
    {
    }

    public async Task<Post?> GetPostWithAudienceAsync(Guid postId)
    {
        return await _dbSet
            .Include(p => p.Audiences)
            .FirstOrDefaultAsync(p => p.Id == postId && !p.IsDeleted);
    }

    public async Task<List<Post>> GetPostsByAuthorAsync(Guid authorId)
    {
        return await _dbSet
            .Where(p => p.AuthorId == authorId && !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task SoftDeleteAsync(Guid postId)
    {
        var post = await _dbSet.FindAsync(postId);

        if (post is not null)
        {
            post.IsDeleted = true;
        }
    }
}