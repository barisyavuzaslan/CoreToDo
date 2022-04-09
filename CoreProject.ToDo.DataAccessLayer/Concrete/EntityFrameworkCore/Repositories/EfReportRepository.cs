using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public int GetAllReportCount()
        {
            using var context = new CoreToDoContext();
            return context.Reports.Count();
        }

        public Report GetProcessWithReportId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Reports.Include(I => I.Process).ThenInclude(I => I.Urgency).Where(I => I.Id == id).FirstOrDefault();


        }

        public int GetReportCountWithAppUserId(int id)
        {
            using var context = new CoreToDoContext();
            var result = context.Processes.Include(I => I.Reports).Where(I => I.AppUserId == id);
            return result.SelectMany(I => I.Reports).Count();
        }
    }
}
