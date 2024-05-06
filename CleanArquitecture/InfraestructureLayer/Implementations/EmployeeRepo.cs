using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfraestructureLayer.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added Employee: "+employee.Name);
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee == null)
                return new ServiceResponse(false, "Employee that you are looking for is not found");

            appDbContext.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted Employee: "+employee.Name);
        }

        public async Task<List<Employee>> GetAsync() => await appDbContext.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) => await appDbContext.Employees.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            appDbContext.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true,"Updated Employee");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}
