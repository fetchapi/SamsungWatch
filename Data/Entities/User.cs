using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SamsungWatch.Data.Entities;

public class User
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public int Code { get; set; }
    public string? Email { get; set; }
    public bool EmailConfirm { get; set; }
    public string? Password { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = "17f3e221-c34d-4498-a929-ea027d98dfbd",
            UserName = "admin",
            FullName = "Nguyễn Phú Đức",
            Code = 562765,
            Email = "nguyenphuduc62001@gmail.com",
            EmailConfirm = true,
            Password = "FE9989D5012230C4C8DD97BD7D209DEF"
        });
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
                .IsRequired();
        builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(20);
        builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(255);
        builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);
        builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255);
    }
}