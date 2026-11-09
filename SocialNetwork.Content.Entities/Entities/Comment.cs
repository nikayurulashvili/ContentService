namespace SocialNetwork.Content.Entities.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}