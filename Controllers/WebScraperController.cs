using Microsoft.AspNetCore.Mvc;

namespace WebScraperApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebScraperAppController : ControllerBase
    {
        private readonly ILogger<WebScraperAppController> _logger;

        public WebScraperAppController(ILogger<WebScraperAppController> logger)
        {
            _logger = logger;
        }
    }
}
