using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.EF;

namespace SamsungWatch.Controllers;

public class CategoryController : BaseController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly SamsungWatchDbContext _context;

    public CategoryController(ILogger<CategoryController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("category")]
    public async Task<IActionResult> Index()
    {
        var listCategory = await _context.Categories.ToListAsync();
        return View(listCategory);
    }
}