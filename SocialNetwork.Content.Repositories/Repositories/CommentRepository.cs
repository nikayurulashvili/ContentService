using Microsoft.EntityFrameworkCore;
using SocialNetwork.Content.Entities.Entities;
using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Interfaces;
using SocialNetwork.Content.Repositories.Repositories;

namespace SocialNetwork.Content.Repositories.Implementations;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ContentDbContext context)
        : base(context)
    {
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(Guid postId)
    {
        return await _dbSet
            .Where(c => c.PostId == postId && !c.IsDeleted)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Comment>> GetCommentsByAuthorAsync(Guid authorId)
    {
        return await _dbSet
            .Where(c => c.AuthorId == authorId && !c.IsDeleted)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task SoftDeleteAsync(Guid commentId)
    {
        var comment = await _dbSet.FindAsync(commentId);

        if (comment is not null)
        {
            comment.IsDeleted = true;
        }
    }
}