using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetWithID(int id);
        List<Table> GetAll();
    }
}
