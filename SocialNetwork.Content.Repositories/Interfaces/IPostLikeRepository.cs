using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Repositories.Interfaces;

public interface IPostLikeRepository : IBaseRepository<PostLike>
{
    Task<List<PostLike>> GetLikesByPostIdAsync(Guid postId);

    Task<bool> IsLikedByUserAsync(Guid postId, Guid userId);

    Task RemoveLikeAsync(Guid postId, Guid userId);

    Task<int> GetLikesCountAsync(Guid postId);
}