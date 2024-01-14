using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController : BaseApiController // Inherits from ControllerBase class
{
    private readonly DataContext _context; // Declares a private field to hold an instance of DataContext

    public UsersController(DataContext context)
    {
        _context = context;  // Initializes the DataContext through constructor injection
    }

    // Handles GET requests to retrieve all users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync(); // Retrieves all users asynchronously from the database
        return users; // Returns a list of users as ActionResult
    }

    // Handles GET requests to retrieve a specific user by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id); // Retrieves a specific user by ID asynchronously from the database
    }
}
