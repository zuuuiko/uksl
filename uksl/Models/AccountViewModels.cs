using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uksl.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запам'ятати цей браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "обов'язкове")]
        [EmailAddress(ErrorMessage = "не дійсне значення")]
        [System.Web.Mvc.Remote("CheckEmail", "Account", ErrorMessage = "Користувач з таким email-ом вже існує.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "обов'язкове")]
        [StringLength(100, ErrorMessage = "{0} має складатися мінімум з {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        [Compare("Password", ErrorMessage = "Пароль і підтвердження паролю не співпадають.")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Поле '{0}' обов'язке для заповнення.")]
        //[DataType(DataType.Text)]
        [Display(Name = "Нікнейм")]
        [System.Web.Mvc.Remote("CheckName", "Account", ErrorMessage = "Користувач з таким Нікнеймом вже існує.")]
        //[StringLength(15, ErrorMessage = "{0} має складатися від {2} до {1} символів.", MinimumLength = 2)]
        public string NickName { get; set; }

        //[Required(ErrorMessage ="Поле '{0}' обов'язке для заповнення.")]
        //[DataType(DataType.Text)]
        [Display(Name = "Ім'я")]
        //[StringLength(30, ErrorMessage = "{0} має складатися від {2} до {1} символів.", MinimumLength = 2)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Поле '{0}' обов'язке для заповнення.")]
        //[DataType(DataType.Text)]
        [Display(Name = "Прізвище")]
        //[StringLength(30, ErrorMessage = "{0} має складатися від {2} до {1} символів.", MinimumLength = 2)]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Поле '{0}' обов'язке для заповнення.")]
        //[DataType(DataType.Text)]
        [Display(Name = "По-батькові")]
        //[StringLength(30, ErrorMessage = "{0} має складатися від {2} до {1} символів.", MinimumLength = 2)]
        public string MiddleName { get; set; }

        //[Required(ErrorMessage = "Поле '{0}' обов'язке для заповнення.")]
        //[DataType(DataType.Date)]
        [Display(Name = "Дата народження")]
        public string BirthDateText { get; set; }
        public DateTime? BirthDate { get; set; }
        //[Required(ErrorMessage = "Поле '{0}' обов'язке для заповнення.")]
        [DataType(DataType.Text)]
        [Display(Name = "Університет")]
        public string UniversityName { get; set; }
        public int? UniversityId { get; set; }
    }
    //public class University
    //{
    //    public int Id { get; set; }
    //    public string ShortName { get; set; }
    //    public string LongName { get; set; }
    //}
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль має складатися мінімум з {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        [Compare("Password", ErrorMessage = "Пароль і підтвердження паролю не співпадають.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
