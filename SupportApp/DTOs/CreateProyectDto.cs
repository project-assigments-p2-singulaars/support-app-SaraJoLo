namespace SupportApp.DTOs;

public class CreateProyectDto
{
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
    
}