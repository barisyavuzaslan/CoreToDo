using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }
        public void Delete(Urgency table)
        {
            _urgencyDal.Delete(table);
        }

        public List<Urgency> GetAll()
        {
            return _urgencyDal.GetAll();
        }

        public Urgency GetWithID(int id)
        {
            return _urgencyDal.GetWithID(id);
        }

        public void Save(Urgency table)
        {
            _urgencyDal.Save(table);
        }

        public void Update(Urgency table)
        {
            _urgencyDal.Update(table);
        }
    }
}
