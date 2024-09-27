using JWTAuthentication.API.Arguments;
using JWTAuthentication.API.Data.DatabaseContexts;
using JWTAuthentication.API.Entities;
using JWTAuthentication.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWTAuthentication.API.Data.Repositories;

public sealed class UserRepository(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ApplicationDbContext dbContext)
    : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        var rn = await userManager.CreateAsync(user, user.PasswordHash!);
    }

    public Task<User?> GetByPredicateAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken) =>
        dbContext.Users.FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<bool> LoginAsync(LoginArgument loginArgument)
    {
        var signInResult = await signInManager.PasswordSignInAsync(loginArgument.Email, loginArgument.Password, false, false);

        return signInResult.Succeeded;
    }

    public Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken) =>
        dbContext.Users.AnyAsync(u => u.UserName == userName, cancellationToken);
}
