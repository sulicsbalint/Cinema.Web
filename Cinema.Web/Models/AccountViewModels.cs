using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class LoginViewModel
    {
        [DisplayName("Név")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Jelszó")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [DisplayName("Név")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Jelszó")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Jelszó megerősítése")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordRepeat { get; set; }
    }
}
