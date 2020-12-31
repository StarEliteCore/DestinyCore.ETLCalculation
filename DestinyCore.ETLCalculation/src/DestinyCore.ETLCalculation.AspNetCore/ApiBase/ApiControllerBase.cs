using Microsoft.AspNetCore.Mvc;

namespace DestinyCore.ETLCalculation.AspNetCore.ApiBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}