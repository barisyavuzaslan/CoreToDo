using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Delete(Notification table)
        {
            _notificationDal.Delete(table);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetNotReads(int AppUserId)
        {
            return _notificationDal.GetNotReads(AppUserId);
        }

        public Notification GetWithID(int id)
        {
            return _notificationDal.GetWithID(id);
        }

        public int NotReadNotificationWithAppUserId(int id)
        {
            return _notificationDal.NotReadNotificationWithAppUserId(id);
        }

        public void Save(Notification table)
        {
            _notificationDal.Save(table);
        }

        public void Update(Notification table)
        {
            _notificationDal.Update(table);
        }
    }
}
