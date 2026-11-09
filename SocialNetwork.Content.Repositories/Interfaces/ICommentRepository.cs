using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Repositories.Interfaces;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<List<Comment>> GetCommentsByPostIdAsync(Guid postId);

    Task<List<Comment>> GetCommentsByAuthorAsync(Guid authorId);

    Task SoftDeleteAsync(Guid commentId);
}