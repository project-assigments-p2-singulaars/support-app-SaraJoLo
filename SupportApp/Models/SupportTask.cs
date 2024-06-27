using System.ComponentModel.DataAnnotations;

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
    
    public int ProyectId { get; set; }
    
    public Proyects.Proyects Proyect { get; set; }
}