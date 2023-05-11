using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Size
{
    public int SizeId { get; set; }
    public string? SizeName { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 1,
            SizeName = "40mm"
        });

        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 2,
            SizeName = "41mm"
        });

        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 3,
            SizeName = "42mm"
        });

        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 4,
            SizeName = "44mm"
        });

        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 5,
            SizeName = "45mm"
        });

        modelBuilder.Entity<Size>().HasData(new Size
        {
            SizeId = 6,
            SizeName = "46mm"
        });
    }
}

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes");

        builder.HasKey(x => x.SizeId);

        builder.Property(x => x.SizeId)
                .UseIdentityColumn()
                .IsRequired();
        builder.Property(x => x.SizeName)
                .IsRequired()
                .HasMaxLength(10);
    }
}
