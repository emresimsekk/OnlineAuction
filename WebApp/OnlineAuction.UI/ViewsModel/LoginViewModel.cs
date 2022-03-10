using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.UI.ViewsModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Pasword min 4 must be character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
