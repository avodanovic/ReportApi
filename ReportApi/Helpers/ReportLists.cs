using Report.Data.Dtos;
using System;
using System.Collections.Generic;

namespace ReportApi.Helpers
{
    public class ReportLists
    {
        public static object GetReportList(string reportName)
        {
            if (reportName.Equals("UserDetails", StringComparison.InvariantCultureIgnoreCase))
            {
                var userList = new List<UserDto>();
                for (int i = 0; i < 1000; i++)
                {
                    userList.Add(new UserDto()
                    {
                        FirstName = $"Name{i}",
                        LastName = $"Surname{i}",
                        Email = $"name{i}@gmail.com",
                        Phone = $"091 569 {i}"
                    });
                }
                return userList;
            }
            else if (reportName.Equals("Companies", StringComparison.InvariantCultureIgnoreCase))
            {
                var companies = new List<CompanyDto>();
                for (int i = 0; i < 100; i++)
                {
                    companies.Add(new CompanyDto()
                    {
                        Name = $"Company{i}",
                        EmployeesNumber = i
                    });
                }
                return companies;
            }

            return null;
        }
    }
}
