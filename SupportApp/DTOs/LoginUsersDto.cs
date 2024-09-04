using System.ComponentModel.DataAnnotations;

namespace SupportApp.Proyects;

public class LoginUsersDto
{
    public class LoginDto
    {
        [Microsoft.Build.Framework.Required]
        [EmailAddress]
        public string Email { get; set; }

        [Microsoft.Build.Framework.Required]
        public string Password { get; set; }
    }
}