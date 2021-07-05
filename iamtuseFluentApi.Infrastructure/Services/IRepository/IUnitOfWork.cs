using System;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository Employee { get; }
        public IGenderRepository Gender { get; }
        Task Save();
    }
}
