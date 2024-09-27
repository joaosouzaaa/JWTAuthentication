using JWTAuthentication.API.Arguments;
using JWTAuthentication.API.DataTransferObjects.User;
using JWTAuthentication.API.Entities;

namespace JWTAuthentication.API.Interfaces.Mappers;

public interface IUserMapper
{
    User CreateRequestToDomain(CreateUserRequest createRequest);
    GetUserByIdResponse DomainToGetByIdResponse(User user);
    LoginArgument LoginRequestToDomain(LoginRequest loginRequest);
}
