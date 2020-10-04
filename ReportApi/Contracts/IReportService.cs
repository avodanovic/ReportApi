namespace ReportApi.Contracts
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName, string reportType, string dsName = null, object reportList = null);
    }
}
