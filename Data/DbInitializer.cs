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
          ColorName = "Trắng bạc",
          ColorCode = "#CECECE"
        },
        new Color
        {
          ColorName = "Trắng",
          ColorCode = "#FFFFFF"
        },

        new Color
        {
          ColorName = "Đen",
          ColorCode = "#000000"
        },

        new Color
        {
          ColorName = "Vàng hồng",
          ColorCode = "#E1AE8F"
        },

        new Color
        {
          ColorName = "Xanh đen",
          ColorCode = "#00401F"
        },

        new Color
        {
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
            ConditionName = "FullBox, Đẹp keng",
            ConditionColor = "#D4EDBD"
        },

        new Condition
        {
            ConditionName = "NoBox, Đẹp keng",
            ConditionColor = "#C0E1F6"
        },

        new Condition
        {
            ConditionName = "FullBox, Xước nhẹ",
            ConditionColor = "#FFE5A1"
        },

        new Condition
        {
            ConditionName = "NoBox, Xước nhẹ",
            ConditionColor = "#FFCFC9"
        },

        new Condition
        {
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
            SizeName = "40mm"
        },

       new Size
        {
            SizeName = "41mm"
        },

       new Size
        {
            SizeName = "42mm"
        },

       new Size
        {
            SizeName = "44mm"
        },

       new Size
        {
            SizeName = "45mm"
        },

       new Size
        {
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
            StatusName = "Đã chốt, chưa cọc",
            StatusColor = "#FFCFC9"
        },

       new Status
        {
            StatusName = "Đã chốt, có cọc",
            StatusColor = "#FFE5A1"
        },

       new Status
        {
            StatusName = "Đang gửi",
            StatusColor = "#D4EDBD"
        },

       new Status
        {
            StatusName = "Đã giao",
            StatusColor = "#E6CFF3"
        },

       new Status
        {
            StatusName = "Đã nhận tiền",
            StatusColor = "#C0E1F6"
        },

       new Status
        {
            StatusName = "Sẵn hàng Hà Nội",
            StatusColor = "#E9EAED"
        },

       new Status
        {
            StatusName = "Sẵn hàng TP.HCM",
            StatusColor = "#C6DCE1"
        },

       new Status
        {
            StatusName = "Đang về",
            StatusColor = "#FFC8AB"
        },

       new Status
        {
            StatusName = "Trả hàng",
            StatusColor = "#A3A4A9"
        }
            });
        }

        if (!_context.Categories.Any())
        {
            var category1 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 4 Series",
                SeoAlias = "samsung-galaxy-watch-4-series",
                sortOrder = 0,
                ParentId = null
            };
            _context.Categories.Add(category1);
            _context.SaveChanges();

            var category2 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 5 Series",
                SeoAlias = "samsung-galaxy-watch-5-series",
                sortOrder = 0,
                ParentId = null
            };
            _context.Categories.Add(category2);
            _context.SaveChanges();

            var category3 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 4",
                SeoAlias = "samsung-galaxy-watch-4",
                sortOrder = 1,
                ParentId = category1.CategoryId
            };
            _context.Categories.Add(category3);
            _context.SaveChanges();

            var category4 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 4 Classic",
                SeoAlias = "samsung-galaxy-watch-4-classic",
                sortOrder = 1,
                ParentId = category1.CategoryId
            };
            _context.Categories.Add(category4);
            _context.SaveChanges();

            var category5 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 5",
                SeoAlias = "samsung-galaxy-watch-5",
                sortOrder = 1,
                ParentId = category2.CategoryId
            };
            _context.Categories.Add(category5);
            _context.SaveChanges();

            var category6 = new Category
            {
                CategoryName = "Samsung Galaxy Watch 5 Pro",
                SeoAlias = "samsung-galaxy-watch-5-pro",
                sortOrder = 1,
                ParentId = category2.CategoryId
            };
            _context.Categories.Add(category6);
            _context.SaveChanges();
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