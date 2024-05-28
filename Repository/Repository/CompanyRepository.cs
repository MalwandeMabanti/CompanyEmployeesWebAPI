using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) 
        { }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(_ => _.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(_ => _.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();
    }
}
