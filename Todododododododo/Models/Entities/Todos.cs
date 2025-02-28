using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todododododododo.Models.Entities;

public class Todos
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Content { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public Users User { get; set; } 
}