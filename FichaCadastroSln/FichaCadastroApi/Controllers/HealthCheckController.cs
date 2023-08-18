using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace FichaCadastroApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService healthCheckService;
        
        public HealthCheckController(HealthCheckService healthCheckService, IWebHostEnvironment Environment)
        {
            this.healthCheckService = healthCheckService;
        }

        [HttpGet]
        public ActionResult Get(CancellationToken cancellationToken = default)
        {
            HealthReport report = this.healthCheckService.CheckHealthAsync().GetAwaiter().GetResult();
            
            return report.Status == HealthStatus.Healthy ? this.Ok(report) : this.StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
        }
    }
}
