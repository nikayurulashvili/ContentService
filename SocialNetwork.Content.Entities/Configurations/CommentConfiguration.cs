using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Entities.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Text)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.IsDeleted)
            .IsRequired();

        builder.HasIndex(c => new
        {
            c.PostId,
            c.IsDeleted,
            c.CreatedAt,
            c.Id
        })
        .HasDatabaseName("IX_Comment_Post");

        builder.HasOne<Post>()
            .WithMany()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<UserReplica>()
            .WithMany()
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}