using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="Le {0} doit contenir au moins {2} caracteres",MinimumLength =6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [Compare("Password",ErrorMessage ="mot de passe différent")]
        public string ConfirmPassword { get; set; }

    }
}
