using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Interfaces
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetNotReads(int AppUserId);
        int NotReadNotificationWithAppUserId(int id);
    }
}
