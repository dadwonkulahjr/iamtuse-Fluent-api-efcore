using iamtuseFluentApi.Domain.Entities;
using iamtuseFluentApi.Persistence.Infrastructure;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository.Repository
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task Update(Employee employeeToUpadate)
        {
            var find = await _applicationDbContext.FindAsync<Employee>(employeeToUpadate.EmployeeId);
            if (find != null)
            {
                find.FirstName = employeeToUpadate.FirstName;
                find.LastName = employeeToUpadate.LastName;
                find.Salary = employeeToUpadate.Salary;
                find.Email = employeeToUpadate.Email;
                find.GenderId = employeeToUpadate.GenderId;
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
