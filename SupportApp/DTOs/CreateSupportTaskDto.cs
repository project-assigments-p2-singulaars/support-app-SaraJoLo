using System.ComponentModel.DataAnnotations;

namespace SupportApp.Proyects;

public class CreateSupportTaskDto
{
    [StringLength(50), Required]
    public required string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}