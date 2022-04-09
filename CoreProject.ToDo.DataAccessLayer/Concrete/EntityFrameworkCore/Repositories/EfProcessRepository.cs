using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProcessRepository : EfGenericRepository<Process>, IProcessDal
    {
        public Process GetProcessWithUrgencyAndId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.Urgency).FirstOrDefault(I => !I.Status && I.Id == id);
        }

        public List<Process> GetWithAppUserId(int appUserId)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Where(I => I.AppUserId == appUserId).ToList();

        }

        public List<Process> GetWithTables()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.Urgency).Include(I => I.AppUser).Include(I => I.Reports).Where(I => !I.Status).OrderByDescending(I => I.CreateDate).ToList();
        }

        public List<Process> GetWithUrgencyAndNotCompleted()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.Urgency).Where(I => !I.Status).OrderByDescending(I => I.CreateDate).ToList();
        }
        public Process GetReportsWithProcessId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.Reports).Include(I => I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }

        public List<Process> GetWithTables(Expression<Func<Process, bool>> filter)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.Urgency).Include(I => I.AppUser).Include(I => I.Reports).Where(I => !I.Status).OrderByDescending(I => I.CreateDate).Where(filter).ToList();
        }

        public List<Process> GetCompletedProcessWithAllTables(out int totalPage, int userId, int activePage = 1)
        {
            using var context = new CoreToDoContext();
            var returnValue = context.Processes.Include(I => I.Urgency).Include(I => I.AppUser).Include(I => I.Reports).Where(I => I.AppUserId == userId && I.Status).OrderByDescending(I => I.CreateDate);
            totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public int GetProcessCountCompletedWithAppUserId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Count(I => I.AppUserId == id && I.Status);
        }

        public int GetProcessNotCompletedWithAppUserId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Processes.Count(I => I.AppUserId == id && !I.Status);
        }

        public int NotAsssignProcessCount()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Count(I => I.AppUserId == null && !I.Status);
        }

        public int GetCompletedProcessCount()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Count(I=>I.Status);
        }
    }
}
