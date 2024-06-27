using System.ComponentModel.DataAnnotations;

namespace SupportApp.Proyects;

public class SupportTaskDto
{ 
    [Key]
    public int Id { get; set; }
    
    [StringLength(50), Required]
    public required string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int ProjectId { get; set; }
    // public Project Project { get; set; } = null!;

}