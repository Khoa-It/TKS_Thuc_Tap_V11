using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace TKS_Thuc_Tap_V11_Web.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration config)
            : base(config) { }

    }
}
