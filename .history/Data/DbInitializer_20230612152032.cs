using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsungWatch.Data
{
  public class DbInitializer
  {
    private readonly BHPNTDbContext _context;

    public DbInitializer(BHPNTDbContext context)
    {
      _context = context;
    }

    public async Task Seed()
    {
    }
  }
}