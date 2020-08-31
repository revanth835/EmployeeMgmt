using AppDemo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IMapper _mapper;

        public EmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<string> Add(EmployeeModel employee)
        {
            var dbModel = _mapper.Map<Employee>(employee);
            dbModel.Id = Guid.NewGuid().ToString();
            dbModel.IsActive = true;
            using (var db = new SQLiteContext())
            {
                db.EmployeeDBModel.Add(dbModel);
                db.SaveChanges();
            }
            return dbModel.Id;
        }

        public async Task<int> Delete(string empId)
        {
            using (var db = new SQLiteContext())
            {
                var emp = (from a in db.EmployeeDBModel where a.Id == empId select a).SingleOrDefault();
                db.EmployeeDBModel.Remove(emp);
                return db.SaveChanges();
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            using (var db = new SQLiteContext())
            {
                return (from a in db.EmployeeDBModel select a).ToList();
            }
        }

        public async Task<Employee> GetById(string empId)
        {
            using (var db = new SQLiteContext())
            {
                return (from a in db.EmployeeDBModel where a.Id == empId select a).SingleOrDefault();
            }
        }

        public async Task<int> Update(EmployeeModel employee)
        {
            using (var db = new SQLiteContext())
            {
                var dbModel = _mapper.Map<Employee>(employee);
                db.EmployeeDBModel.Update(dbModel);
                return db.SaveChanges();
            }
        }
    }
}
