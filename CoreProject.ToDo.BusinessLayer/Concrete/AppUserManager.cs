using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;

        }

        public List<DualHelper> GetMaxCompletedProcessWithPersonels()
        {
            return _appUserDal.GetMaxCompletedProcessWithPersonels();
        }

        public List<DualHelper> GetMaxWorkTheProcessWithPersonels()
        {
            return _appUserDal.GetMaxWorkTheProcessWithPersonels();
        }

        public List<AppUser> GetNoContentAdmin()
        {
            return _appUserDal.GetNoContentAdmin();
        }
        public List<AppUser> GetNoContentAdmin(out int totalpage, string search, int activepage = 1)
        {
            return _appUserDal.GetNoContentAdmin(out totalpage, search, activepage);
        }
    }
}
