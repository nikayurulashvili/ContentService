using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Entities.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Text)
            .HasMaxLength(3000)
            .IsRequired();

        builder.Property(p => p.Visibility)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.IsDeleted)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Post_Visibility",
                "[Visibility] IN (0, 1)");
        });

        builder.HasIndex(p => new
        {
            p.IsDeleted,
            p.CreatedAt,
            p.Id
        })
            .HasDatabaseName("IX_Post_Feed")
            .IsDescending(false, true, true);

        builder.HasIndex(p => new
        {
            p.AuthorId,
            p.CreatedAt,
            p.Id
        })
            .HasDatabaseName("IX_Post_Author")
            .IsDescending(false, true, true);

        builder.HasOne<UserReplica>()
            .WithMany()
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}