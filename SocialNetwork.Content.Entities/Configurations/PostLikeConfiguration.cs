using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Entities.Configurations;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.HasKey(pl => new
        {
            pl.PostId,
            pl.UserId
        });

        builder.Property(pl => pl.CreatedAt)
            .IsRequired();

        builder.HasOne<Post>()
            .WithMany()
            .HasForeignKey(pl => pl.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<UserReplica>()
            .WithMany()
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}