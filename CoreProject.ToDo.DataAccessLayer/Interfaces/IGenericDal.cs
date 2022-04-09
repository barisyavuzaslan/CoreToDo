using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Interfaces
{
    public interface IGenericDal<Table> where Table : class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetWithID(int id);
        List<Table> GetAll();
    }
}
