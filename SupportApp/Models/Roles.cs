using SupportApp.relationTable;

namespace SupportApp.Models;

public class Roles
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProyectUserRole> ProyectUserRoles { get; set; }
    
}