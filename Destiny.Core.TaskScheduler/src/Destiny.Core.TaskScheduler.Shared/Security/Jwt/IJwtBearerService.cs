using System;

namespace Destiny.Core.TaskScheduler.Shared.Security.Jwt
{
    public interface IJwtBearerService : IScopedDependency
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}