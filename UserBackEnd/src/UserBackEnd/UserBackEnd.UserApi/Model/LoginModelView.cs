using System.ComponentModel.DataAnnotations;

namespace UserBackEnd.UserApi.Model
{
    public class LoginModelView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
