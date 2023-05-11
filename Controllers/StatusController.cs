using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.EF;

namespace SamsungWatch.Controllers;

public class StatusController : BaseController
{
    private readonly ILogger<StatusController> _logger;
    private readonly SamsungWatchDbContext _context;

    public StatusController(ILogger<StatusController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("status")]
    public async Task<IActionResult> Index()
    {
        var listStatus = await _context.Statuses.ToListAsync();
        return View(listStatus);
    }
}