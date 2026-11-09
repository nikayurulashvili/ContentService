using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Repositories.Interfaces;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<Post?> GetPostWithAudienceAsync(Guid postId);

    Task<List<Post>> GetPostsByAuthorAsync(Guid authorId);

    Task SoftDeleteAsync(Guid postId);
}