using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class ProcessManager : IProcessService
    {

        private readonly IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        public void Delete(Process table)
        {
            _processDal.Delete(table);
        }

        public List<Process> GetAll()
        {
            return _processDal.GetAll();
        }

        public int GetCompletedProcessCount()
        {
            return _processDal.GetCompletedProcessCount();
        }

        public List<Process> GetCompletedProcessWithAllTables(out int totalPage, int userId, int activePage)
        {
            return _processDal.GetCompletedProcessWithAllTables(out totalPage, userId, activePage);
        }

        public int GetProcessCountCompletedWithAppUserId(int id)
        {
            return _processDal.GetProcessCountCompletedWithAppUserId(id);
        }

        public int GetProcessNotCompletedWithAppUserId(int id)
        {
            return _processDal.GetProcessNotCompletedWithAppUserId(id);
        }

        public Process GetProcessWithUrgencyAndId(int id)
        {
            return _processDal.GetProcessWithUrgencyAndId(id);
        }

        public Process GetReportsWithProcessId(int id)
        {
            return _processDal.GetReportsWithProcessId(id);
        }

        public List<Process> GetWithAppUserId(int appUserId)
        {
            return _processDal.GetWithAppUserId(appUserId);
        }

        public Process GetWithID(int id)
        {
            return _processDal.GetWithID(id);
        }

        public List<Process> GetWithTables()
        {
            return _processDal.GetWithTables();
        }

        public List<Process> GetWithTables(Expression<Func<Process, bool>> filter)
        {
            return _processDal.GetWithTables(filter);
        }

        public List<Process> GetWithUrgencyAndNotCompleted()
        {
            return _processDal.GetWithUrgencyAndNotCompleted();
        }

        public int NotAsssignProcessCount()
        {
            return _processDal.NotAsssignProcessCount();
        }

        public void Save(Process table)
        {
            _processDal.Save(table);
        }

        public void Update(Process table)
        {
            _processDal.Update(table);
        }
    }
}
