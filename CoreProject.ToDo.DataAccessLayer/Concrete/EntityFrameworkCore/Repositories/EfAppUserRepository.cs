using CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using CoreProject.ToDo.DataAccessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNoContentAdmin()
        {
            /*
            select * from AspNetUsers u
            inner join AspNetUserRoles ur on ur.UserId=u.Id
            inner join AspNetRoles r on r.Id=ur.RoleId
            where r.Name='Member'
             */
            using var context = new CoreToDoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultuser, resultuserrole) => new
            {
                user = resultuser,
                userRole = resultuserrole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userroles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                Surname = I.user.Surname,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName
            }).ToList();


        }

        public List<AppUser> GetNoContentAdmin(out int totalpage, string search, int activepage = 1)
        {
            /*
           select * from AspNetUsers u
           inner join AspNetUserRoles ur on ur.UserId=u.Id
           inner join AspNetRoles r on r.Id=ur.RoleId
           where r.Name='Member'
            */
            using var context = new CoreToDoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultuser, resultuserrole) => new
            {
                user = resultuser,
                userRole = resultuserrole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userroles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                Surname = I.user.Surname,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName
            });

            totalpage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(search))
            {
                result = result.Where(I => I.Name.ToLower().Contains(search.ToLower()) || I.Surname.ToLower().Contains(search.ToLower()));
                totalpage = (int)Math.Ceiling((double)result.Count() / 3);
            }


            result = result.Skip((activepage - 1) * 3).Take(3);


            return result.ToList();

        }
        /*select TOP(5) U.Name+' '+U.Surname AdSoyad,Count(P.Id) IsSayisi from Processes P
inner join AspNetUsers U on U.Id=P.AppUserId
where P.Status=1
group by U.Name+' '+U.Surname
order by Count(P.Id) desc*/

        public List<DualHelper> GetMaxCompletedProcessWithPersonels()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.AppUser).Where(I => I.Status).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                ProcessCount = I.Count()

            }).ToList();
        }
        public List<DualHelper> GetMaxWorkTheProcessWithPersonels()
        {
            using var context = new CoreToDoContext();
            return context.Processes.Include(I => I.AppUser).Where(I => !I.Status && I.AppUserId != null).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                ProcessCount = I.Count()

            }).ToList();
        }


    }
}
