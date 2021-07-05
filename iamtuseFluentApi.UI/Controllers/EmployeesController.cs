using iamtuseFluentApi.Infrastructure.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iamtuseFluentApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWok;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWok = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(new { data = await _unitOfWok.Employee.GetAllMatchingEntityType(
                navigationProperty:"Gender")});
        }
    }
}
