using JWTAuthentication.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.API.Data.DatabaseContexts;

public sealed class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options);
