﻿using System;
using System.Collections.Generic;

namespace ReportApi.Helpers
{
    public class ReportHelper
    {
        public static string GetReportDs(string reportName)
        {
            if (ReportNameDs.ContainsKey(reportName))
            {
                return ReportNameDs[reportName];
            }
            return null;
        }

        private static readonly Dictionary<string, string> ReportNameDs = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "UserDetails", "dsUsers"},
            { "Companies", "dsCompanies" }
        };
    }
}
