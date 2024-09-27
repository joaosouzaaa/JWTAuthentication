using JWTAuthentication.API.Arguments;
using JWTAuthentication.API.DataTransferObjects.User;
using JWTAuthentication.API.Entities;
using JWTAuthentication.API.Interfaces.Mappers;

namespace JWTAuthentication.API.Mappers;

public sealed class UserMapper : IUserMapper
{
    public User CreateRequestToDomain(CreateUserRequest createRequest) =>
        new()
        {
            Email = createRequest.Email,
            UserName = createRequest.Email,
            PasswordHash = createRequest.Password
        };

    public GetUserByIdResponse DomainToGetByIdResponse(User user) =>
        new(user.Id,
            user.UserName!);

    public LoginArgument LoginRequestToDomain(LoginRequest loginRequest) =>
        new(loginRequest.Email,
            loginRequest.Password);
}
