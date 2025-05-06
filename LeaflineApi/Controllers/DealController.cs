using Microsoft.AspNetCore.Mvc;

namespace LeaflineApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealController : ControllerBase
    {

        private readonly ILogger<DealController> _logger;

        public DealController(ILogger<DealController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> testDeal() {
           return "Hello, Leafline!";
        }

    }
}
