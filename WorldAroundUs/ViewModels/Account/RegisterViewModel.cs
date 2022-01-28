using System;
using System.ComponentModel.DataAnnotations;

namespace WorldAroundUs.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string PasswordConfirm { get; set; }

    }
}