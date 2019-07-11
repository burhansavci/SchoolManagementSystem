using System.ComponentModel.DataAnnotations;

namespace SMS.UI.Models
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Lütfen kullanıcı isminizi giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen parlanızı giriniz.")]
        public string Password { get; set; }
    }
}