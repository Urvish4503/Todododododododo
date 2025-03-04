using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models;

public class CreateUserDto
{
    [Required]
    [MaxLength(25)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
}