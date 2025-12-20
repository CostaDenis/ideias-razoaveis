using ideias_razoaveis.Enums;

namespace ideias_razoaveis.Models;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public EPostStatus PostStatus { get; set; }
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }
    public Author? Author { get; set; }
    public Guid AuthorId { get; set; }
    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}