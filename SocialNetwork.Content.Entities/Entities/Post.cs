namespace SocialNetwork.Content.Entities.Entities;

public class Post
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Text { get; set; } = string.Empty;

    public byte Visibility { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<PostAudience> Audiences { get; set; }
        = new List<PostAudience>();
}