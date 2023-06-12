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
        },
        new Color
        {
          ColorId = 2,
          ColorName = "Trắng",
          ColorCode = "#FFFFFF"
        },

        new Color
        {
          ColorId = 3,
          ColorName = "Đen",
          ColorCode = "#000000"
        },

        new Color
        {
          ColorId = 4,
          ColorName = "Vàng hồng",
          ColorCode = "#E1AE8F"
        },

        new Color
        {
          ColorId = 5,
          ColorName = "Xanh đen",
          ColorCode = "#00401F"
        },

        new Color
        {
          ColorId = 6,
          ColorName = "Tím",
          ColorCode = "#AC89D8"
        },
      });
    }
    if (!_context.Conditions.Any())
    {
      _context.Conditions.AddRange(new List<Condition>()
            {
                new Condition
        {
            ConditionId = 1,
            ConditionName = "FullBox, Đẹp keng",
            ConditionColor = "#D4EDBD"
        },

        new Condition
        {
            ConditionId = 2,
            ConditionName = "NoBox, Đẹp keng",
            ConditionColor = "#C0E1F6"
        },

        new Condition
        {
            ConditionId = 3,
            ConditionName = "FullBox, Xước nhẹ",
            ConditionColor = "#FFE5A1"
        },

        new Condition
        {
            ConditionId = 4,
            ConditionName = "NoBox, Xước nhẹ",
            ConditionColor = "#FFCFC9"
        },

        new Condition
        {
            ConditionId = 5,
            ConditionName = "Khác",
            ConditionColor = "#E9EAED"
        }
            })
        }


  }
}