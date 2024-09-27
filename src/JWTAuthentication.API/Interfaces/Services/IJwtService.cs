using JWTAuthentication.API.Entities;

namespace JWTAuthentication.API.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
