using Microsoft.AspNetCore.Mvc;

namespace Eventful.Api.Controllers
{
    [Route("api/version")]
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