using ideias_razoaveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ideias_razoaveis.Data.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");

        builder.Property(p => p.Title)
            .HasColumnName("title")
            .HasColumnType("varchar")
            .HasMaxLength(120)
            .IsRequired();

        builder.HasIndex(p => p.Slug, "ix_post_title")
            .IsUnique();

        builder.Property(p => p.Slug)
            .HasColumnName("slug")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired();

        builder.HasIndex(p => p.Slug, "ix_post_slug")
            .IsUnique();

        builder.Property(p => p.Summary)
            .HasColumnName("summary")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Text)
            .HasColumnName("text")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(p => p.PostStatus)
            .HasColumnName("status")
            .HasColumnType("varchar")
            .HasMaxLength(9)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Posts)
            .HasConstraintName("fk_post_category")
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CategoryId)
            .HasColumnName("category_id")
            .HasColumnType("uuid");

        builder.HasOne(p => p.Author)
            .WithMany(a => a.Posts)
            .HasConstraintName("fk_post_author")
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.AuthorId)
            .HasColumnName("author_id")
            .HasColumnType("uuid");

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(p => p.PublishedAt)
            .HasColumnName("published_at")
            .HasColumnType("timestamptz");

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}