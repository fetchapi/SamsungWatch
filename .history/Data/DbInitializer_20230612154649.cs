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
    if (!_context.Users.Any())
    {
      _context.Users.AddRange(new List<User>()
    {
      new User
        {
          UserId = "17f3e221-c34d-4498-a929-ea027d98dfbd",
          UserName = "admin",
          FullName = "Nguyễn Phú Đức",
          Code = 562765,
          Email = "nguyenphuduc62001@gmail.com",
          EmailConfirm = true,
          Password = "FE9989D5012230C4C8DD97BD7D209DEF"
        }
            });
    }
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
            });
    }
    if (!_context.Sizes.Any())
    {
      _context.Sizes.AddRange(new List<Size>()
      {
        new Size
        {
            SizeId = 1,
            SizeName = "40mm"
        },

       new Size
        {
            SizeId = 2,
            SizeName = "41mm"
        },

       new Size
        {
            SizeId = 3,
            SizeName = "42mm"
        },

       new Size
        {
            SizeId = 4,
            SizeName = "44mm"
        },

       new Size
        {
            SizeId = 5,
            SizeName = "45mm"
        },

       new Size
        {
            SizeId = 6,
            SizeName = "46mm"
        }
      });
    }


    if (!_context.Statuses.Any())
    {
      _context.Statuses.AddRange(new List<Status>()
            {
               new Status
        {
            StatusId = 1,
            StatusName = "Đã chốt, chưa cọc",
            StatusColor = "#FFCFC9"
        },

       new Status
        {
            StatusId = 2,
            StatusName = "Đã chốt, có cọc",
            StatusColor = "#FFE5A1"
        },

       new Status
        {
            StatusId = 3,
            StatusName = "Đang gửi",
            StatusColor = "#D4EDBD"
        },

       new Status
        {
            StatusId = 4,
            StatusName = "Đã giao",
            StatusColor = "#E6CFF3"
        },

       new Status
        {
            StatusId = 5,
            StatusName = "Đã nhận tiền",
            StatusColor = "#C0E1F6"
        },

       new Status
        {
            StatusId = 6,
            StatusName = "Sẵn hàng Hà Nội",
            StatusColor = "#E9EAED"
        },

       new Status
        {
            StatusId = 7,
            StatusName = "Sẵn hàng TP.HCM",
            StatusColor = "#C6DCE1"
        },

       new Status
        {
            StatusId = 8,
            StatusName = "Đang về",
            StatusColor = "#FFC8AB"
        },

       new Status
        {
            StatusId = 9,
            StatusName = "Trả hàng",
            StatusColor = "#A3A4A9"
        }
            });
    }
    if (!_context.Categories.Any())
    {
      _context.Categories.AddRange(new List<Category>()
            {
                 new Category
        {
            CategoryId = 1,
            CategoryName = "Samsung Galaxy Watch 4 Series",
            SeoAlias = "samsung-galaxy-watch-4-series",
            ParentId = 0
        },

        new Category
        {
            CategoryId = 2,
            CategoryName = "Samsung Galaxy Watch 5 Series",
            SeoAlias = "samsung-galaxy-watch-5-series",
            ParentId = 0
        },

        new Category
        {
            CategoryId = 3,
            CategoryName = "Samsung Galaxy Watch 4",
            SeoAlias = "samsung-galaxy-watch-4",
            ParentId = 0
        },

        new Category
        {
            CategoryId = 4,
            CategoryName = "Samsung Galaxy Watch 4 Classic",
            SeoAlias = "samsung-galaxy-watch-4-classic",
            ParentId = 0
        },

        new Category
        {
            CategoryId = 5,
            CategoryName = "Samsung Galaxy Watch 5",
            SeoAlias = "samsung-galaxy-watch-5",
            ParentId = 0
        },

        new Category
        {
            CategoryId = 6,
            CategoryName = "Samsung Galaxy Watch 5 Pro",
            SeoAlias = "samsung-galaxy-watch-5-pro",
            ParentId = 0
        },
            });
    }
    if (!_context.Products.Any())
    {
      _context.Products.AddRange(new List<Product>()
      {

      });
    }
    await _context.SaveChangesAsync();
  }
}