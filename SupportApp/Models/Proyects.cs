using System.ComponentModel.DataAnnotations;
using SupportApp.relationTable;

namespace SupportApp.Proyects;
using System.Text.Json.Serialization;

public class Proyects
 {
     [Key]
     public int Id { get; set; }
     
     [StringLength(50), Required ]
     public required string Name { get; set; } = null!;
     
     [StringLength(500), Required ]
     public string Description { get; set; } = null!;
     
     public DateTime CreDateTime { get; set; }
     
     public DateTime? FinishDateTime { get; set; }
     
     // public ICollection<SupportTask.SupportTask> SupportTask { get; set; } = new List<SupportTask.SupportTask>();
     public ICollection<SupportTask> SupportTask { get; set; } = new List<SupportTask>();
     public ICollection<ProyectUserRole> ProyectUserRoles { get; set; }
 }