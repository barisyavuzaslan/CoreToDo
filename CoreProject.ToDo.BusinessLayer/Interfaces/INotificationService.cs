using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetNotReads(int AppUserId);
        int NotReadNotificationWithAppUserId(int id);
    }
}
