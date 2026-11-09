using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Implementations;
using SocialNetwork.Content.Repositories.Interfaces;

namespace SocialNetwork.Content.Repositories.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContentDbContext _context;

    private readonly Lazy<IPostRepository> _posts;
    private readonly Lazy<IPostAudienceRepository> _postAudiences;
    private readonly Lazy<ICommentRepository> _comments;
    private readonly Lazy<IPostLikeRepository> _postLikes;

    public IPostRepository Posts => _posts.Value;

    public IPostAudienceRepository PostAudiences => _postAudiences.Value;

    public ICommentRepository Comments => _comments.Value;

    public IPostLikeRepository PostLikes => _postLikes.Value;

    public UnitOfWork(ContentDbContext context)
    {
        _context = context;

        _posts = new Lazy<IPostRepository>(
            () => new PostRepository(_context));

        _postAudiences = new Lazy<IPostAudienceRepository>(
            () => new PostAudienceRepository(_context));

        _comments = new Lazy<ICommentRepository>(
            () => new CommentRepository(_context));

        _postLikes = new Lazy<IPostLikeRepository>(
            () => new PostLikeRepository(_context));
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}