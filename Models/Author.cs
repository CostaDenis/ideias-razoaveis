namespace ideias_razoaveis.Models;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}