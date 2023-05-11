using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Color
{
    public int ColorId { get; set; }
    public string? ColorName { get; set; }
    public string? ColorCode { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 1,
            ColorName = "Trắng bạc",
            ColorCode = "#CECECE"
        });

        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 2,
            ColorName = "Trắng",
            ColorCode = "#FFFFFF"
        });

        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 3,
            ColorName = "Đen",
            ColorCode = "#000000"
        });

        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 4,
            ColorName = "Vàng hồng",
            ColorCode = "#E1AE8F"
        });

        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 5,
            ColorName = "Xanh đen",
            ColorCode = "#00401F"
        });

        modelBuilder.Entity<Color>().HasData(new Color
        {
            ColorId = 6,
            ColorName = "Tím",
            ColorCode = "#AC89D8"
        });
    }
}

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors");

        builder.HasKey(x => x.ColorId);

        builder.Property(x => x.ColorId)
                .UseIdentityColumn()
                .IsRequired();
        builder.Property(x => x.ColorName)
                .IsRequired()
                .HasMaxLength(50);
        builder.Property(x => x.ColorCode)
                .IsRequired()
                .HasMaxLength(10);
    }
}
