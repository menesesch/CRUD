using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfraestructureLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer.Implementations
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task<ServiceResponse> AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
