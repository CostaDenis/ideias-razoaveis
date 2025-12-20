using ideias_razoaveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ideias_razoaveis.Data.Mappings;

public class PostTagMapping : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.ToTable("post_tags");

        builder.HasKey(pt => new { pt.PostId, pt.TagId });

        builder.HasOne(pt => pt.Post)
            .WithMany(p => p.PostTags)
            .HasConstraintName("fk_posttag_post")
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(pt => pt.PostId)
            .HasColumnName("post_id")
            .HasColumnType("uuid");

        builder.HasOne(pt => pt.Tag)
            .WithMany(t => t.PostTags)
            .HasConstraintName("fk_posttag_tag")
            .HasForeignKey(pt => pt.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(pt => pt.TagId)
            .HasColumnName("tag_id")
            .HasColumnType("uuid");
    }
}