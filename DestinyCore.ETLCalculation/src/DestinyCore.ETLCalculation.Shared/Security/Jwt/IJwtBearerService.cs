using System;

namespace DestinyCore.ETLCalculation.Shared.Security.Jwt
{
    public interface IJwtBearerService : IScopedDependency
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}