using Contracts;
using Entities.Models;
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

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(_ => _.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(_ => _.Name).ToList();

#pragma warning disable CS8603 // Possible null reference return.
        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
            FindByCondition(_ => _.CompanyId.Equals(companyId) && _.Id.Equals(id), trackChanges)
            .SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.


    }
}
