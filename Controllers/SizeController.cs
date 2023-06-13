using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.EF;
using SamsungWatch.Data.Entities;

using SamsungWatch.Models;


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
  [HttpGet("create-size")]
  public IActionResult Create()
  {
    return View();
  }
  [HttpPost("create-size")]
  public async Task<IActionResult> Create(SizeCreateRequest request)
  {
    if (request.SizeName == null)
    {
      return View(request);
    }
    var size = new Size
    {
      SizeName = request.SizeName,
    };

    await _context.Sizes.AddAsync(size);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return RedirectToAction("Index", "Size");
    }
    return View(request);
  }
  [HttpPost("delete-size")]
  public async Task<IActionResult> Delete(int id)
  {
    var condition = await _context.Sizes.FindAsync(id);
    if (condition == null) return View();
    _context.Sizes.Remove(condition);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return RedirectToAction("Index", "Size");
    }
    return View();
  }

  [HttpPost("update-size")]
  public async Task<IActionResult> Update(int id, SizeViewModel request)
  {
    var condition = await _context.Sizes.FindAsync(id);
    if (condition == null) return View();
    condition.SizeId = id;

    condition.SizeName = request.SizeName;

    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return RedirectToAction("Index", "Size");
    }
    return View();
  }
}