using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.EF;

namespace SamsungWatch.Controllers;

public class SizeController : BaseController
{
    private readonly ILogger<SizeController> _logger;
    private readonly SamsungWatchDbContext _context;

    public SizeController(ILogger<SizeController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("size")]
    public async Task<IActionResult> Index()
    {
        var listSize = await _context.Sizes.ToListAsync();
        return View(listSize);
    }
}