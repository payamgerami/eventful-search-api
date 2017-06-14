using Microsoft.AspNetCore.Mvc;

namespace Eventful.Api.Controllers
{
    [Route("api/[controller]")]
    public class VersionController
    {
        // GET api/version
        [HttpGet]
        public string Get()
        {
            return "V1";
        }
    }
}