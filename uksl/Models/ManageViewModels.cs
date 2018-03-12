using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace uksl.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        [Display(Name = "Нікнейм")]
        [System.Web.Mvc.Remote("CheckName", "Manage", ErrorMessage = "Користувач з таким Нікнеймом вже існує.")]
        public string NickName { get; set; }
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }
        [Display(Name = "Дата народження")]
        public string BirthDateText { get; set; }
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Університет")]
        public string UniversityName { get; set; }
        public int? UniversityId { get; set; }
        [EmailAddress(ErrorMessage = "не дійсне значення")]
        [System.Web.Mvc.Remote("CheckEmail", "Manage", ErrorMessage = "Користувач з таким email-ом вже існує.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Пароль має складатися мінімум з {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження нового паролю")]
        [Compare("NewPassword", ErrorMessage = "Новий пароль і підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Поточний пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль має складатися мінімум з {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження нового паролю")]
        [Compare("NewPassword", ErrorMessage = "Новий пароль і підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}