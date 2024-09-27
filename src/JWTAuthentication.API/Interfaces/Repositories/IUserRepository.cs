using JWTAuthentication.API.Arguments;
using JWTAuthentication.API.Entities;
using System.Linq.Expressions;

namespace JWTAuthentication.API.Interfaces.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByPredicateAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> LoginAsync(LoginArgument loginArgument);
    Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken);
}
