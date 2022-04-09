using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>,IUrgencyDal
    {
    }
}
