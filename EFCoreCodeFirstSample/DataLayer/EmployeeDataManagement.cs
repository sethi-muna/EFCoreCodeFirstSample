using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.DataLayer
{
    public class EmployeeDataManagement : IDataRepository<Employees>
    {
        readonly EmployeesContext _employeesContext;

        public EmployeeDataManagement(EmployeesContext context)
        {
            _employeesContext = context;
        }

        public IEnumerable<Employees> GetAll()
        {
            return _employeesContext.Employees.ToList();
        }
        public Employees Get(long id)
        {
            return _employeesContext.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
        }

        public void Add(Employees entity)
        {
            _employeesContext.Employees.Add(entity);
            _employeesContext.SaveChanges();
        }
        public void Update(Employees employee, Employees entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;

            _employeesContext.SaveChanges();
        }

        public void Delete(Employees entity)
        {
            _employeesContext.Employees.Remove(entity);
            _employeesContext.SaveChanges();
        }

    }
}
