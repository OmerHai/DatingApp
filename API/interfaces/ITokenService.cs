using API.Entities;

namespace API.Interfaces;

// Interface for defining token-related operations
public interface ITokenService
{
    // Method signature for creating a token based on an AppUser
    string CreateToken(AppUser user);
}
