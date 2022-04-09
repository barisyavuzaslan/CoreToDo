using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNoContentAdmin();
        List<AppUser> GetNoContentAdmin(out int totalpage, string search, int activepage = 1);
        List<DualHelper> GetMaxCompletedProcessWithPersonels();
        List<DualHelper> GetMaxWorkTheProcessWithPersonels();
    }
}
