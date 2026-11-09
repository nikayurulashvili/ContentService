namespace SocialNetwork.Content.Contracts.Events;

public sealed record PostCreatedEvent
{
    public Guid PostId { get; init; }

    public Guid AuthorId { get; init; }

    public string Text { get; init; } = string.Empty;

    public byte Visibility { get; init; }

    public IReadOnlyCollection<Guid> AudienceUserIds { get; init; }
        = Array.Empty<Guid>();

    public DateTime CreatedAt { get; init; }
}