using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.DataLayer
{
    public class UserInfoDataManagement : IDataRepository<UserInfo>
    {
        readonly EmployeesContext _employeesContext;

        public UserInfoDataManagement(EmployeesContext context)
        {
            _employeesContext = context;
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return _employeesContext.UserInfos.ToList();
        }
        public UserInfo Get(long id)
        {
            return _employeesContext.UserInfos.SingleOrDefault(userinfo => userinfo.UserId == id);
        }

        public void Add(UserInfo entity)
        {
            _employeesContext.UserInfos.Add(entity);
            _employeesContext.SaveChanges();
        }
        public void Update(UserInfo employee, UserInfo entity)
        {
           //un implemented..
        }

        public void Delete(UserInfo entity)
        {
            _employeesContext.UserInfos.Remove(entity);
            _employeesContext.SaveChanges();
        }

    }
}
