using System.ComponentModel.DataAnnotations;

namespace Todododododododo.Models;

public class UpdateUserDto
{
    [MaxLength(25, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string Username { get; set; } = string.Empty;

    [EmailAddress] public string Email { get; set; } = string.Empty;

    [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
    public string Password { get; set; } = string.Empty;
}