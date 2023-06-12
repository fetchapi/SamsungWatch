using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamsungWatch.Data.EF;

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

  }
}