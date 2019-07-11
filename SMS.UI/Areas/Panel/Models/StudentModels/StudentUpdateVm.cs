using System.ComponentModel.DataAnnotations;

namespace SMS.UI.Areas.Panel.Models
{
    public class StudentUpdateVm
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı isminizi giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen bir isim giriniz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen bir soyisim giriniz.")]
        public string LastName { get; set; }
        public string ParentPhoneNumber { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen bir TC numarası giriniz.")]
        public string TcNo { get; set; }
        public string Password { get; set; }
        public string GroupLevel { get; set; }
        public string GroupName { get; set; }
        public string StudentId { get; set; }
        public int GroupId { get; set; }
        public string RedirectUrl { get; set; }
    }
}