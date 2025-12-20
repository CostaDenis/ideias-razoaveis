namespace ideias_razoaveis.Models;

public class PostTag
{
    public Post Post { get; set; } = null!;
    public Guid PostId { get; set; }
    public Tag Tag { get; set; } = null!;
    public Guid TagId { get; set; }
}