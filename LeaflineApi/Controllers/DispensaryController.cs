using Microsoft.AspNetCore.Mvc;

namespace LeaflineApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispensaryController : ControllerBase
    {

        private readonly ILogger<DispensaryController> _logger;

        public DispensaryController(ILogger<DispensaryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> testDispensary() {
          return "Hello, Leafline!";
        }


    }
}
