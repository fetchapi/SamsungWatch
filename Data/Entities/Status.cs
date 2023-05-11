using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Status
{
    public int StatusId { get; set; }
    public string? StatusName { get; set; }
    public string? StatusColor { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 1,
            StatusName = "Đã chốt, chưa cọc",
            StatusColor = "#FFCFC9"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 2,
            StatusName = "Đã chốt, có cọc",
            StatusColor = "#FFE5A1"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 3,
            StatusName = "Đang gửi",
            StatusColor = "#D4EDBD"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 4,
            StatusName = "Đã giao",
            StatusColor = "#E6CFF3"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 5,
            StatusName = "Đã nhận tiền",
            StatusColor = "#C0E1F6"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 6,
            StatusName = "Sẵn hàng Hà Nội",
            StatusColor = "#E9EAED"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 7,
            StatusName = "Sẵn hàng TP.HCM",
            StatusColor = "#C6DCE1"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 8,
            StatusName = "Đang về",
            StatusColor = "#FFC8AB"
        });

        modelBuilder.Entity<Status>().HasData(new Status
        {
            StatusId = 9,
            StatusName = "Trả hàng",
            StatusColor = "#A3A4A9"
        });
    }
}

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Statuses");

        builder.HasKey(x => x.StatusId);

        builder.Property(x => x.StatusId)
                .UseIdentityColumn()
                .IsRequired();
        builder.Property(x => x.StatusName)
                .IsRequired()
                .HasMaxLength(50);
        builder.Property(x => x.StatusColor)
                .IsRequired()
                .HasMaxLength(10);
    }
}
