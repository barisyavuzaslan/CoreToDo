using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public void Delete(Report table)
        {
            _reportDal.Delete(table);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public int GetAllReportCount()
        {
            return _reportDal.GetAllReportCount();
        }

        public Report GetProcessWithReportId(int id)
        {
            return _reportDal.GetProcessWithReportId(id);
        }

        public int GetReportCountWithAppUserId(int id)
        {
            return _reportDal.GetReportCountWithAppUserId(id);
        }

        public Report GetWithID(int id)
        {
            return _reportDal.GetWithID(id);
        }

        public void Save(Report table)
        {
            _reportDal.Save(table);
        }

        public void Update(Report table)
        {
            _reportDal.Update(table);
        }
    }
}
