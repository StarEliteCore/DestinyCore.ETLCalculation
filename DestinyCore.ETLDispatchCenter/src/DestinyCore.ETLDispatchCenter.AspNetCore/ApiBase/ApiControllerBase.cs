using Microsoft.AspNetCore.Mvc;

namespace DestinyCore.ETLDispatchCenter.AspNetCore.ApiBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}