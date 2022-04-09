using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNoContentAdmin();
        List<AppUser> GetNoContentAdmin(out int totalpage, string search, int activepage = 1);
        List<DualHelper> GetMaxCompletedProcessWithPersonels();
        List<DualHelper> GetMaxWorkTheProcessWithPersonels();

    }
}
