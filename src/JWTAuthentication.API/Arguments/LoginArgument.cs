﻿namespace JWTAuthentication.API.Arguments;

public sealed record LoginArgument(
    string Email,
    string Password);
