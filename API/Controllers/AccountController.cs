using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// Controller for handling account-related operations
public class AccountController : BaseApiController
{
    private readonly DataContext _context; // Declares a private field to hold an instance of DataContext

    public AccountController(DataContext context)
    {
        _context = context; // Initializes the DataContext through constructor injection
    }

    // Handles HTTP POST requests for user registration
    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {
        // Check if the provided username already exists
        if (await UserExists(registerDto.Username))
            return BadRequest("Username is taken");

        using var hmac = new HMACSHA512(); // Creating an instance of HMACSHA512 for password hashing

        // Creating a new AppUser instance with username, password hash, and password salt
        var user = new AppUser
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user); // Adding the new user to the database context
        await _context.SaveChangesAsync(); // Saving changes to the database
        return user; // Returning the registered user as ActionResult
    }

    // Checks if a user with the given username already exists in the database
    private async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}
