using iamtuseFluentApi.Domain.Entities;
using iamtuseFluentApi.Persistence.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository.Repository
{
    public class GenderRepository : GeneralRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenderRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetGenderListSelectListItems()
        {
            return _applicationDbContext.Gender.Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.GenderId.ToString()
            });
        }
        public async Task Update(Gender genderToUpdate)
        {
            var find = await _applicationDbContext.FindAsync<Gender>(genderToUpdate.GenderId);
            if (find != null)
            {
                find.Name = genderToUpdate.Name;
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
