using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? SeoAlias { get; set; }
    public int ParentId { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 1,
            CategoryName = "Samsung Galaxy Watch 4 Series",
            SeoAlias = "samsung-galaxy-watch-4-series",
            ParentId = 0
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 2,
            CategoryName = "Samsung Galaxy Watch 5 Series",
            SeoAlias = "samsung-galaxy-watch-5-series",
            ParentId = 0
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 3,
            CategoryName = "Samsung Galaxy Watch 4",
            SeoAlias = "samsung-galaxy-watch-4",
            ParentId = 0
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 4,
            CategoryName = "Samsung Galaxy Watch 4 Classic",
            SeoAlias = "samsung-galaxy-watch-4-classic",
            ParentId = 0
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 5,
            CategoryName = "Samsung Galaxy Watch 5",
            SeoAlias = "samsung-galaxy-watch-5",
            ParentId = 0
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 6,
            CategoryName = "Samsung Galaxy Watch 5 Pro",
            SeoAlias = "samsung-galaxy-watch-5-pro",
            ParentId = 0
        });
    }
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