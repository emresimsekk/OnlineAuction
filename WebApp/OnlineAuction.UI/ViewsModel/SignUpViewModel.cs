using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.UI.ViewsModel
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="Username is required")]
        [Display(Name ="User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Buyer is required")]
        [Display(Name = "Buyer ")]
        public bool IsBuyer { get; set; }

        [Required(ErrorMessage = "Seller is required")]
        [Display(Name = "Seller ")]
        public bool IsSeller { get; set; }

        public int UserSelectTypeId { get; set; }
    }
}
