using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todododododododo.Models.Entities;

public class Todos
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public Users User { get; set; }
}