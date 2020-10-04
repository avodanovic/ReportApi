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
        private readonly IReportLists _reportLists;

        public ReportController(IReportService reportService, IReportLists reportLists)
        {
            _reportService = reportService;
            _reportLists = reportLists;
        }

        [HttpGet("{reportName}/{reportType?}")]
        public ActionResult Get(string reportName, string reportType = ReportService.defaultReportType)
        {
            var returnString = _reportService.GenerateReportAsync(reportName, reportType, ReportHelper.GetReportDs(reportName), _reportLists.GetReportList(reportName));
            return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, $"{reportName}.{ReportService.GetReportTypeExtension(reportType)}");
        }
    }
}
