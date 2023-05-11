using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class Condition
{
    public int ConditionId { get; set; }
    public string? ConditionName { get; set; }
    public string? ConditionColor { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Condition>().HasData(new Condition
        {
            ConditionId = 1,
            ConditionName = "FullBox, Đẹp keng",
            ConditionColor = "#D4EDBD"
        });

        modelBuilder.Entity<Condition>().HasData(new Condition
        {
            ConditionId = 2,
            ConditionName = "NoBox, Đẹp keng",
            ConditionColor = "#C0E1F6"
        });

        modelBuilder.Entity<Condition>().HasData(new Condition
        {
            ConditionId = 3,
            ConditionName = "FullBox, Xước nhẹ",
            ConditionColor = "#FFE5A1"
        });

        modelBuilder.Entity<Condition>().HasData(new Condition
        {
            ConditionId = 4,
            ConditionName = "NoBox, Xước nhẹ",
            ConditionColor = "#FFCFC9"
        });

        modelBuilder.Entity<Condition>().HasData(new Condition
        {
            ConditionId = 5,
            ConditionName = "Khác",
            ConditionColor = "#E9EAED"
        });
    }
}

public class ConditionConfiguration : IEntityTypeConfiguration<Condition>
{
    public void Configure(EntityTypeBuilder<Condition> builder)
    {
        builder.ToTable("Conditions");

        builder.HasKey(x => x.ConditionId);

        builder.Property(x => x.ConditionId)
                .UseIdentityColumn()
                .IsRequired();
        builder.Property(x => x.ConditionName)
                .IsRequired()
                .HasMaxLength(50);
        builder.Property(x => x.ConditionColor)
                .IsRequired()
                .HasMaxLength(10);
    }
}
