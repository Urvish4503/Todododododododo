using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models;

public class CreateUserDto
{
    [Required]
    [MaxLength(25)]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}