using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetProcessWithReportId(int id);
        int GetReportCountWithAppUserId(int id);
        int GetAllReportCount();
    }
}
