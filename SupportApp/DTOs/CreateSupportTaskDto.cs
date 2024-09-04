using System.ComponentModel.DataAnnotations;

namespace SupportApp.Proyects;

public class CreateSupportTaskDto
{
    [Required]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
}