using System.ComponentModel.DataAnnotations;
using SupportApp.Models;
using SupportApp.relationTable;

namespace SupportApp;

public class SupportTask
{
    [Key]
    public int Id { get; set; }
     
    [StringLength(50), Required ]
    public required string Name { get; set; } = null!;
     
    [StringLength(500), Required ]
    public string Description { get; set; } = null!;
     
    public DateTime StartDate { get; set; }
     
    public DateTime? FinishDate { get; set; }
    
    public bool TaskDone { get; set; }
    public int ProyectId { get; set; }
    public Proyects.Proyects Proyects { get; set; } = null!;

    public ICollection<ProyectUserRole> ProyectUserRoles { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}