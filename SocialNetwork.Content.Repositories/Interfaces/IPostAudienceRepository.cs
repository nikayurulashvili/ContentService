using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Repositories.Interfaces;

public interface IPostAudienceRepository : IBaseRepository<PostAudience>
{
    Task<List<PostAudience>> GetAudienceByPostIdAsync(Guid postId);

    Task<List<PostAudience>> GetPostsByUserIdAsync(Guid userId);

    Task RemoveAudienceByPostIdAsync(Guid postId);
}