using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetNotReads(int AppUserId)
        {
            using var context = new CoreToDoContext();
            return context.Notifications.Where(I => I.AppUserId == AppUserId && !I.Status).ToList();
        }

        public int NotReadNotificationWithAppUserId(int id)
        {
            using var context = new CoreToDoContext();
            return context.Notifications.Count(I => I.AppUserId == id && !I.Status);
        }
    }
}
