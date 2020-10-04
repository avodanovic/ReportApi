using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportApi.Contracts
{
    public interface IReportLists
    {
        object GetReportList(string reportName);
    }
}
