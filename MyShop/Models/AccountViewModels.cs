using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class RegisterViewModel
    {
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Password { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string RePassword { get; set; }
    }



    public class LoginViewModel
    {
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Password { get; set; }

        [Display(Name = " مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
