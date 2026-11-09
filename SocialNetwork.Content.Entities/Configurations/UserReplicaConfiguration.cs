using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Content.Entities.Entities;

namespace SocialNetwork.Content.Entities.Configurations;

public class UserReplicaConfiguration : IEntityTypeConfiguration<UserReplica>
{
    public void Configure(EntityTypeBuilder<UserReplica> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserId)
            .IsRequired();

        builder.Property(u => u.IsActive)
            .IsRequired();
    }
}