using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungWatch.Models;
using SamsungWatch.Data.EF;
using SamsungWatch.Data.Entities;
using SamsungWatch.Utilities;
using SamsungWatch.Utilities.Mail;

namespace SamsungWatch.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly SamsungWatchDbContext _context;

    public UserController(ILogger<UserController> logger, SamsungWatchDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        if (request.Password != request.PasswordCF)
        {
            ViewBag.errPassword = "Mật khẩu xác nhận không trùng khớp";
            return View(request);
        }

        var checkEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (checkEmail != null)
        {
            ViewBag.errEmail = "Địa chỉ email đã tồn tại";
            return View(request);
        }

        var checkUserName = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
        if (checkUserName != null)
        {
            ViewBag.errUserName = "Tên đăng nhập đã được sử dụng";
            return View(request);
        }

        String Code = SystemVariable.GetRanDomCode(6);
        User user = new User()
        {
            UserId = Guid.NewGuid().ToString(),
            FullName = request.FullName,
            UserName = request.UserName,
            Email = request.Email,
            Password = MD5Encrypt.Encrypt(request.Password),
            Code = Int32.Parse(Code),
            EmailConfirm = false
        };

        await _context.Users.AddAsync(user);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            if (request.Email != null)
            {

                // Đọc nội dung từ file HTML
                string htmlBody = System.IO.File.ReadAllText("wwwroot/html/mail-template.html");

                // Thay đổi giá trị của biến Code trong file HTML
                string code = "1234"; // Giá trị thực tế của biến Code
                string formattedHtmlBody = string.Format(htmlBody, code);

                // Gửi email với nội dung HTML được định dạng
                SendMail.SendEmail(request.Email, "Daisy Study", formattedHtmlBody, "");
            }
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string? UserName, int Code)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
        if (user == null)
        {
            ViewBag.errEmail = "Tài khoản không tồn tại";
            return View();
        }

        if (user.Code == Code)
        {
            user.EmailConfirm = true;
            var result = await _context.SaveChangesAsync();
        }
        return View();
    }

    [HttpPost("log-in")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
        if (user == null)
        {
            ViewBag.err = "Tài khoản không tồn tại";
            return View(request);
        }

        if (MD5Encrypt.Encrypt(request.Password) == user.Password)
        {
            var userViewModel = new UserViewModel()
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email
            };
            return View(userViewModel);
        }
        else
        {
            ViewBag.err = "Mật khẩu không chính xác";
            return View(request);
        }
    }
}
