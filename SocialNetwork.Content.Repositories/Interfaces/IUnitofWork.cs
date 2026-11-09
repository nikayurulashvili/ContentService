namespace SocialNetwork.Content.Repositories.Interfaces;

public interface IUnitOfWork
{
    IPostRepository Posts { get; }

    IPostAudienceRepository PostAudiences { get; }

    ICommentRepository Comments { get; }

    IPostLikeRepository PostLikes { get; }

    Task<int> SaveChangesAsync();
}