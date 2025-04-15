using System.ComponentModel.DataAnnotations;

namespace AngularApp2.Server.Models.Dto
{
    public class LoginUserDto
    {

        [MaxLength(40, ErrorMessage ="the length must be less than 40")]
        [EmailAddress(ErrorMessage ="Not the correct form of email")]
        public string Email { get; set; }

        public string Password { get; set; }


    }
}
