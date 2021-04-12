using Microsoft.AspNetCore.Mvc;

namespace DestinyCore.WorkNode.AspNetCore.ApiBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}