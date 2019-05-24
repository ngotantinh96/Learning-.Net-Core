using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LifetimeDemonstration.Web.Services;
using Microsoft.Extensions.Logging;

namespace LifetimeDemonstration.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly GuidService _guidService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(GuidService guidService, ILogger<HomeController> logger)
        {
            _guidService = guidService;
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            var guid = _guidService.GetGuid();

            var logMessage = $"Controller: The GUID from GuidService is {guid}";

            _logger.LogInformation(logMessage);

            var messages = new List<string>
            {
                HttpContext.Items["MiddlewareGuid"].ToString(),
                logMessage
            };
            
            return Ok(messages);
        }
    }
}