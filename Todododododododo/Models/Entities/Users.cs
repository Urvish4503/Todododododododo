using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models.Entities;

public class Users
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? LastLogin { get; set; }

    public ICollection<Todos> Todos { get; set; }
}