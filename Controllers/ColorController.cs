using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Models;
using SamsungWatch.Data.EF;
using SamsungWatch.Data.Entities;

namespace SamsungWatch.Controllers;

public class ColorController : BaseController
{
    private readonly ILogger<ColorController> _logger;
    private readonly SamsungWatchDbContext _context;

    public ColorController(ILogger<ColorController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("color")]
    public async Task<IActionResult> Index()
    {
        var listColor = await _context.Colors.ToListAsync();
        return View(listColor);
    }

    [HttpGet("create-color")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create-color")]
    public async Task<IActionResult> Create(ColorCreateRequest request)
    {
        if (request.ColorCode == null)
        {
            return View(request);
        }
        var color = new Color
        {
            ColorName = request.ColorName,
            ColorCode = request.ColorCode.ToUpper()
        };

        await _context.Colors.AddAsync(color);
        var result = await _context.SaveChangesAsync();
        if (result > 0)
        {
            return RedirectToAction("Index", "Color");
        }
        return View(request);
    }

}