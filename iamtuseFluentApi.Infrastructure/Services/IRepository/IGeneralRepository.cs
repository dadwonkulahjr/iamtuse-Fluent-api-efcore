using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository
{
    public interface IGeneralRepository<MyEntity> where MyEntity : class
    {
       Task<IEnumerable<MyEntity>> GetAllMatchingEntityType(Expression<Func<MyEntity, bool>> filterEntityPass = null,Func<IQueryable<MyEntity>, IOrderedQueryable<MyEntity>> orderEntityPass = null, string navigationProperty = null);
       Task<MyEntity> Get(int id);
       Task<MyEntity> Get(MyEntity myEntity);

        Task<MyEntity> GetFirstOrDefaultMatchingEntityType(Expression<Func<MyEntity, bool>> filterEntityPass = null, string navigationProperty = null);

        Task Add(MyEntity myEntityToAdd);
       
    }
}
