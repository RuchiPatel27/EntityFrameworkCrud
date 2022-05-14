using EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Repository
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code
                };
                if(model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Details = model.Address.Details,
                        Country = model.Address.Country,
                        State = model.Address.State
                    };
                }
                context.Employees.Add(emp);
                context.SaveChanges();
                return emp.Id;
            }
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employees.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Code = x.Code,
                    Address = new AddressModel()
                    {
                        Id = x.Address.Id,
                        Country = x.Address.Country,
                        State = x.Address.State,
                        Details = x.Address.Details
                    }
                }).ToList();
                return result;
            }
        }
        public EmployeeModel GetEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employees.Where(x => x.Id == id).Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Code = x.Code,
                    Address = new AddressModel()
                    {
                        Id = x.Address.Id,
                        Country = x.Address.Country,
                        State = x.Address.State,
                        Details = x.Address.Details
                    }
                }).FirstOrDefault();
                return result;
            }
        }
        public bool UpdateEmployee(int id,EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);
                if(employee != null)
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Email = model.Email;
                    employee.Code = model.Code;
                }
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);
                if(employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
            }
                return false;
        }
    }
}
