using System.ComponentModel.DataAnnotations;

namespace TrainHoppersTARpe23.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "New Password Again")]
        [Compare("NewPassword",ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
