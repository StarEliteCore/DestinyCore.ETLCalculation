using System;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Security.Jwt
{
    public interface IJwtBearerService : IScopedDependency
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}