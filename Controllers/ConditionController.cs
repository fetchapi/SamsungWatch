using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data.EF;
using SamsungWatch.Models;

namespace SamsungWatch.Controllers;

public class ConditionController : BaseController
{
    private readonly ILogger<ConditionController> _logger;
    private readonly SamsungWatchDbContext _context;

    public ConditionController(ILogger<ConditionController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("condition")]
    public async Task<IActionResult> Index()
    {
        var listCondition = await _context.Conditions.ToListAsync();
        return View(listCondition);
    }

    [HttpGet("create-condition")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create-condition")]
    public async Task<IActionResult> Create(ConditionCreateRequest request)
    {
        if (request.ConditionColor == null)
        {
            return View(request);
        }
        var Condition = new Data.Entities.Condition
        {
            ConditionName = request.ConditionName,
            ConditionColor = request.ConditionColor.ToUpper()
        };

        await _context.Conditions.AddAsync(Condition);
        var result = await _context.SaveChangesAsync();
        if (result > 0)
        {
            return RedirectToAction("Index", "Condition");
        }
        return View(request);
    }

    [HttpPost("delete-condition")]
    public async Task<IActionResult> Delete(int id)
    {
        var condition = await _context.Conditions.FindAsync(id);
        if (condition == null) return View();
        _context.Conditions.Remove(condition);
        var result = await _context.SaveChangesAsync();
        if (result > 0)
        {
            return RedirectToAction("Index", "Condition");
        }
        return View();
    }

    [HttpPost("update-condition")]
    public async Task<IActionResult> Update(int id, ConditionCreateRequest request)
    {
        var condition = await _context.Conditions.FindAsync(id);
        if (condition == null) return View();

        condition.ConditionName = request.ConditionName;
        condition.ConditionColor = request.ConditionColor;
        var result = await _context.SaveChangesAsync();
        if (result > 0)
        {
            return RedirectToAction("Index", "Condition");
        }
        return View();
    }
}