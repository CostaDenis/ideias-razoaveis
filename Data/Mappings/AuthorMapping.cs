using ideias_razoaveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ideias_razoaveis.Data.Mappings;

public class AuthorMapping : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");

        builder.Property(a => a.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Bio)
            .HasColumnName("bio")
            .HasColumnType("varchar")
            .HasMaxLength(600)
            .IsRequired();

        builder.Property(a => a.Slug)
            .HasColumnName("slug")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(a => a.Slug, "ix_author_slug")
            .IsUnique();

        builder.HasMany(a => a.Posts)
            .WithOne(p => p.Author)
            .HasConstraintName("fk_author_post")
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}