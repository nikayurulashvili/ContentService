using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Entities.Configurations;

public class PostAudienceConfiguration : IEntityTypeConfiguration<PostAudience>
{
    public void Configure(EntityTypeBuilder<PostAudience> builder)
    {
        builder.HasKey(pa => new
        {
            pa.PostId,
            pa.UserId
        });

        builder.HasIndex(pa => new
        {
            pa.UserId,
            pa.PostId
        })
        .HasDatabaseName("IX_PostAudience_User");

        builder.HasOne<Post>()
          .WithMany(p => p.Audiences)
            .HasForeignKey(pa => pa.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<UserReplica>()
            .WithMany()
            .HasForeignKey(pa => pa.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}