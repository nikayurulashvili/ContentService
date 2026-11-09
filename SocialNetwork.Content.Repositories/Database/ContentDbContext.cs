using Microsoft.EntityFrameworkCore;
using SocialNetwork.Content.Entities.Entities;
using SocialNetwork.Content.Entities.Configurations;

namespace SocialNetwork.Content.Repositories.Database;

public class ContentDbContext : DbContext
{
    public ContentDbContext(
        DbContextOptions<ContentDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserReplica> UserReplicas => Set<UserReplica>();

    public DbSet<Post> Posts => Set<Post>();

    public DbSet<PostAudience> PostAudiences => Set<PostAudience>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<PostLike> PostLikes => Set<PostLike>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserReplicaConfiguration());

        modelBuilder.ApplyConfiguration(new PostConfiguration());

        modelBuilder.ApplyConfiguration(new PostAudienceConfiguration());

        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        modelBuilder.ApplyConfiguration(new PostLikeConfiguration());
    }
}