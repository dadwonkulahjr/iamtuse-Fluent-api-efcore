using iamtuseFluentApi.Persistence.Infrastructure;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
      
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Employee = new EmployeeRepository(_applicationDbContext);
            Gender = new GenderRepository(_applicationDbContext);
        }

        public IEmployeeRepository Employee { get; private set; }
        public IGenderRepository Gender { get; private set; }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
