using System.ComponentModel.DataAnnotations;

namespace SupportApp.Proyects;

public class SupportTaskDto
{ 
    [Key]
    public int Id { get; set; }
    
    [StringLength(8), Required]
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; } = null;
    
    public int ProjectId { get; set; }

}