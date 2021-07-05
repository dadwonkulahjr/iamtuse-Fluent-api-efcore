using iamtuseFluentApi.Domain.Entities;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        Task Update(Employee employeeToUpadate);
    }
}
