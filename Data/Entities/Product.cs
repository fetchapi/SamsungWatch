using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamsungWatch.Data.Enums;

namespace SamsungWatch.Data.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? Seri { get; set; }

    // category    
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    // color
    public int ColorId { get; set; }
    public virtual Color? Color { get; set; }

    // connection
    public Connection Connection { get; set; }

    // size
    public int SizeId { get; set; }
    public virtual Size? Size { get; set; }

    // condition
    public int ConditionId { get; set; }
    public virtual Condition? Condition { get; set; }

    // status
    public int StatusId { get; set; }
    public virtual Status? Status { get; set; }

    public decimal? CostPrice { get; set; }
    public string? Note { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {

    }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.ProductId);

        builder.Property(x => x.ProductId)
                .UseIdentityColumn()
                .IsRequired();
        builder.Property(x => x.CostPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Note)
                .HasMaxLength(255);
    }
}