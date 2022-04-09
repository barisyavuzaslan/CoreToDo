using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetProcessWithReportId(int id);
        int GetReportCountWithAppUserId(int id);
        int GetAllReportCount();
    }
}
