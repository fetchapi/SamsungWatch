using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.Entities;

namespace SamsungWatch.Data.EF;

public class SamsungWatchDbContext : DbContext
{
  public SamsungWatchDbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new ColorConfiguration());
    modelBuilder.ApplyConfiguration(new ConditionConfiguration());
    modelBuilder.ApplyConfiguration(new SizeConfiguration());
    modelBuilder.ApplyConfiguration(new StatusConfiguration());
    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    modelBuilder.ApplyConfiguration(new ProductConfiguration());
  }

  public DbSet<User> Users { set; get; } = default!;
  public DbSet<Color> Colors { set; get; } = default!;
  public DbSet<Condition> Conditions { set; get; } = default!;
  public DbSet<Size> Sizes { set; get; } = default!;
  public DbSet<Status> Statuses { set; get; } = default!;
  public DbSet<Category> Categories { set; get; } = default!;
  public DbSet<Product> Products { set; get; } = default!;
}