using Microsoft.AspNetCore.Mvc;

namespace DestinyCore.ETLDispatchCenter.AspNetCore.ApiBase
{
    [Route("etl/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
