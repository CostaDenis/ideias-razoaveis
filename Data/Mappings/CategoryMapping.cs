using ideias_razoaveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ideias_razoaveis.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasIndex(c => c.Name, "ix_category_name")
            .IsUnique();

        builder.Property(c => c.Slug)
            .HasColumnName("slug")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(c => c.Slug, "ix_category_slug")
            .IsUnique();

        builder.HasMany(c => c.Posts)
            .WithOne(p => p.Category)
            .HasConstraintName("fk_category_post")
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}