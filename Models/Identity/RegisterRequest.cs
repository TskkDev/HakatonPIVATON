using System.ComponentModel.DataAnnotations;

namespace Pathnostics.Web.Models.Identity;

public class RegisterRequest
{
    [Required] 
    [Display(Name = "Email")] 
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; } = null!;

    [Required]
    [Display(Name = "Название или фио")]
    public string Name { get; set; } = null!;


    [Required]
    [Display(Name = "Компания?")]
    public bool IsCompany { get; set; }
}