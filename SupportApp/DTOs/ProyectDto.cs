namespace SupportApp.Proyects;

public class ProyectDto
{
    
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime CreDateTime { get; set; }
        public DateTime? FinishDateTime { get; set; } = null!;
        public List<SupportTaskDto> SupportTasks { get; set; } = new List<SupportTaskDto>();

}