using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace Sport.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указана почта")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
