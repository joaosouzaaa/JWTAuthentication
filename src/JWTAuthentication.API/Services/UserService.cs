using FluentValidation;
using JWTAuthentication.API.DataTransferObjects.User;
using JWTAuthentication.API.Entities;
using JWTAuthentication.API.Interfaces.Mappers;
using JWTAuthentication.API.Interfaces.Repositories;
using JWTAuthentication.API.Interfaces.Services;
using JWTAuthentication.API.Interfaces.Settings;

namespace JWTAuthentication.API.Services;

public sealed class UserService(
    IUserRepository userRepository,
    IUserMapper userMapper,
    IJwtService jwtService,
    IValidator<User> userValidator,
    INotificationHandler notificationHandler)
    : IUserService
{
    public async Task CreateAsync(CreateUserRequest createUser, CancellationToken cancellationToken)
    {
        if (await userRepository.UserNameExistsAsync(createUser.Email, cancellationToken))
        {
            notificationHandler.AddNotification("Exists", "User Name already exists");

            return;
        }

        var user = userMapper.CreateRequestToDomain(createUser);

        if (!await IsValidAsync(user, cancellationToken))
        {
            return;
        }

        await userRepository.CreateAsync(user);
    }

    public async Task<GetUserByIdResponse?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByPredicateAsync(u => u.Id == id, cancellationToken);

        if (user is null)
        {
            return null;
        }

        return userMapper.DomainToGetByIdResponse(user);
    }

    public async Task<BearerResponse?> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var loginArgument = userMapper.LoginRequestToDomain(loginRequest);

        if (!await userRepository.LoginAsync(loginArgument))
        {
            notificationHandler.AddNotification("Login Failed", "Invalid Credentials.");

            return null;
        }

        var user = await userRepository.GetByPredicateAsync(u => u.UserName == loginArgument.Email, cancellationToken);

        var token = jwtService.GenerateToken(user!);

        return new(token);
    }

    private async Task<bool> IsValidAsync(User user, CancellationToken cancellationToken)
    {
        var validationResult = await userValidator.ValidateAsync(user, cancellationToken);

        if (validationResult.IsValid)
        {
            return true;
        }

        foreach (var error in validationResult.Errors)
        {
            notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);
        }

        return false;
    }
}
