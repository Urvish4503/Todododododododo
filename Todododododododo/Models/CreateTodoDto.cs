using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models;

public class CreateTodoDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public int UserId { get; set; }
}