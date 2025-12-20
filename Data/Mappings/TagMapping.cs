using ideias_razoaveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ideias_razoaveis.Data.Mappings;

public class TagMapping : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tags");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasIndex(t => t.Name, "ix_tag_name")
            .IsUnique();

        builder.Property(t => t.Slug)
            .HasColumnName("slug")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(t => t.Slug, "ix_tag_slug")
            .IsUnique();

    }
}