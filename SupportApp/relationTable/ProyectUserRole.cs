using SupportApp.Models;
using SupportApp.Proyects;

namespace SupportApp.relationTable;

public class ProyectUserRole
{

    public int ProyectId { get; set; }
    public Proyects.Proyects Proyects { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int RoleId { get; set; }
    public Roles Roles { get; set; }
}