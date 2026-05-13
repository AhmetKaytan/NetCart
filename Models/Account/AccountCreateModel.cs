using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class AccountCreateModel
{
    [Required]
    [Display(Name = "Kullanıcı Adı")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Kullanıcı adınız yalnızca sayı ve harf içerebilir")]
    public string Username { get; set; } = null!;

    [Required]
    [Display(Name = "E-posta")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Parola Tekrarı")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parolanız eşleşmiyor")]
    public string ConfirmPassword { get; set; } = null!;
}