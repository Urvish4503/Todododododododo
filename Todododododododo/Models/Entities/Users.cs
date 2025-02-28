using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models.Entities;

public class Users
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime? LastLogin { get; set; }

    public ICollection<Todos> Todos { get; set; } = new List<Todos>();
}