using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table> where Table : class, ITable, new()
    {
        public void Delete(Table table)
        {
            using var context = new CoreToDoContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            using var context = new CoreToDoContext();
            return context.Set<Table>().ToList();
        }

        public Table GetWithID(int id)
        {
            using var context = new CoreToDoContext();
            return context.Set<Table>().Find(id);
        }

        public void Save(Table table)
        {
            using var context = new CoreToDoContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Update(Table table)
        {
            using var context = new CoreToDoContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
    }
}
