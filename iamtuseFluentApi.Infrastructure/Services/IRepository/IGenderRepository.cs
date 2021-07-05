using iamtuseFluentApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository
{
    public interface IGenderRepository : IGeneralRepository<Gender>
    {
        IEnumerable<SelectListItem> GetGenderListSelectListItems();
        Task Update(Gender genderToUpdate);
    }
}
