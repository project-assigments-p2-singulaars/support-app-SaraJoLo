using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SupportApp.relationTable;

namespace SupportApp.Models;


public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<SupportTask> Tasks { get; set; }
    public ICollection<ProyectUserRole> ProyectUserRoles { get; set; }
    

    public User()
    {
        // Constructor vacío requerido por Identity
    }

    public User(string userName, string email) : base(userName)
    {
        Email = email;
        UserName = userName;
    }
    
}