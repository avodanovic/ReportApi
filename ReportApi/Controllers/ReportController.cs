using Microsoft.AspNetCore.Mvc;
using ReportApi.Contracts;
using ReportApi.Helpers;
using ReportApi.Services;

namespace ReportApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{reportName}/{reportType?}")]
        public ActionResult Get(string reportName, string reportType = ReportService.defaultReportType)
        {
            var returnString = _reportService.GenerateReportAsync(reportName, reportType, ReportHelper.GetReportDs(reportName), ReportLists.GetReportList(reportName));
            return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, $"{reportName}.{ReportService.GetReportTypeExtension(reportType)}");
        }
    }
}
