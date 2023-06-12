using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? SeoAlias { get; set; }
    public int sortOrder { get; set; }
    public int? ParentId { get; set; }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.CategoryId);

        builder.Property(x => x.CategoryId)
                .UseIdentityColumn()
                .IsRequired();

        builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(255);
        builder.Property(x => x.SeoAlias)
                .IsRequired()
                .HasMaxLength(255);
        builder.Property(x => x.ParentId)
                .HasDefaultValue(0);
    }
}