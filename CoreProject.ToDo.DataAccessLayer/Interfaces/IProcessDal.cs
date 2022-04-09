using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoreProject.ToDo.DataAccessLayer.Interfaces
{
    public interface IProcessDal : IGenericDal<Process>
    {
        List<Process> GetWithUrgencyAndNotCompleted();
        List<Process> GetWithTables();
        List<Process> GetWithTables(Expression<Func<Process,bool>> filter);
        Process GetProcessWithUrgencyAndId(int id);
        List<Process> GetWithAppUserId(int appUserId);
        Process GetReportsWithProcessId(int id);
        List<Process> GetCompletedProcessWithAllTables(out int totalPage,int userId,int activePage);
        int GetProcessCountCompletedWithAppUserId(int id);
        int GetProcessNotCompletedWithAppUserId(int id);
        int NotAsssignProcessCount();
        int GetCompletedProcessCount();
    }
}
