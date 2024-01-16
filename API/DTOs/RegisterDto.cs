using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

// Data Transfer Object (DTO) for user registration
public class RegisterDto
{
    // Property to store the username provided during registration
    [Required]
    public string Username { get; set; }

    // Property to store the password provided during registration
    [Required]
    public string Password { get; set; }
}
