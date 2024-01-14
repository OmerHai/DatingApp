namespace API.Entities;

// Define a public class named AppUser
public class AppUser
{
    // Public property representing the unique identifier of an AppUser
    public int Id { get; set; }

    // Public property representing the username of an AppUser
    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}
