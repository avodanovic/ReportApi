using AspNetCore.Reporting;
using ReportApi.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReportApi.Services
{
    public enum ReportTypeParams
    {
        word,
        excel,
        pdf
    }

    public enum ReportTypeExtensions
    {
        docx,
        xlsx,
        pdf
    }

    public class ReportService : IReportService
    {
        public const string defaultReportType = "pdf";

        public static string GetReportTypeExtension(string reportType)
        {
            if (reportType.Equals(nameof(RenderType.Word), StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(ReportTypeExtensions.docx);
            }
            else if (reportType.Equals(nameof(RenderType.Excel), StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(ReportTypeExtensions.xlsx);
            }
            
            return nameof(ReportTypeExtensions.pdf);
        }

        public byte[] GenerateReportAsync(string reportName, string reportType, string dsName = null, object reportList = null)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportApi.dll", string.Empty);
            string rdlcFilePath = $"{fileDirPath}ReportFiles\\{reportName}.rdlc";
            var parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");

            var report = new LocalReport(rdlcFilePath);
            if (dsName != null && reportList != null)
            {
                report.AddDataSource(dsName, reportList);
            }
            var result = report.Execute(GetRenderType(reportType), 1, parameters);

            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            return (reportType.ToLower()) switch
            {
                nameof(ReportTypeParams.word) => RenderType.WordOpenXml,
                nameof(ReportTypeParams.excel) => RenderType.ExcelOpenXml,
                _ => RenderType.Pdf,
            };
        }
    }
}
