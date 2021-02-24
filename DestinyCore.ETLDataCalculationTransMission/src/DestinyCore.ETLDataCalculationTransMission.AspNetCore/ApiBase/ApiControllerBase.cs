using Microsoft.AspNetCore.Mvc;

namespace DestinyCore.ETLDataCalculationTransMission.AspNetCore.ApiBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}