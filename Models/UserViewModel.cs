using System.ComponentModel.DataAnnotations;

namespace SamsungWatch.Models;

public class RegisterRequest
{
    [Display(Name = "Tên đăng nhập")]
    public string? UserName { get; set; }

    [Display(Name = "Họ tên")]
    public string? FullName { get; set; }

    [Display(Name = "Địa chỉ email")]
    public string? Email { get; set; }

    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    [Display(Name = "Mật khẩu xác nhận")]
    public string? PasswordCF { get; set; }
}

public class LoginRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class UserViewModel
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public string? Email { get; set; }
}