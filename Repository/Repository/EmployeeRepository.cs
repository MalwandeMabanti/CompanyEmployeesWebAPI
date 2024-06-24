using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(_ => _.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(_ => _.Name).ToListAsync();

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(_ => _.CompanyId.Equals(companyId) && _.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        public void CreateEmployeeForCompany(Guid companyId, Employee employee) 
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);   

    }
}
