using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamsungWatch.Data.EF;
using SamsungWatch.Data.Entities;

namespace SamsungWatch.Data;

public class DbInitializer
{
  private readonly SamsungWatchDbContext _context;

  public DbInitializer(SamsungWatchDbContext context)
  {
    _context = context;
  }

  public async Task Seed()
  {
    if (!_context.Colors.Any())
    {
      _context.Colors.AddRange(new List<Color>()
      {
                new Color
        {
            ColorId = 1,
            ColorName = "Trắng bạc",
            ColorCode = "#CECECE"
        }
            });
    }
  }
}