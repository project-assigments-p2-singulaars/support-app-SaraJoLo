namespace SupportApp.Errors;
using Microsoft.AspNetCore.Identity;

public class CustomErrors : IdentityErrorDescriber
{
    public virtual IdentityError InvaliEmail(string email)
    {
        return new IdentityError
        {
            Code = nameof(InvaliEmail),
            Description = $"El correo {email} no es correcto. Introduce un correo válido"
        };
    }
}