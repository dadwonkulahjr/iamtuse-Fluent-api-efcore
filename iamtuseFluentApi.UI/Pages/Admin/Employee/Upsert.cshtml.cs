using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iamtuseFluentApi.Application.ViewModels;
using iamtuseFluentApi.Infrastructure.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace iamtuseFluentApi.UI.Pages.Admin.Employee
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public EmployeeVM EmployeeVM { get; set; } = new();
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                EmployeeVM.Employee = new();
                EmployeeVM.EmployeeList = await _unitOfWork.Employee.GetAllMatchingEntityType(navigationProperty: "Gender");
                EmployeeVM.GetDropdownListForGender = _unitOfWork.Gender.GetGenderListSelectListItems();
                return Page();
            }
            else
            {
                EmployeeVM.Employee = await _unitOfWork.Employee.GetFirstOrDefaultMatchingEntityType(e => e.EmployeeId == id);

                EmployeeVM.GetDropdownListForGender = _unitOfWork.Gender.GetGenderListSelectListItems();

                if (EmployeeVM.Employee != null)
                {
                    return Page();
                }
            }

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (EmployeeVM.Employee.EmployeeId == 0)
            {
                //Add new record
                await _unitOfWork.Employee.Add(EmployeeVM.Employee);
                await _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            else
            {
                //Update existing record
                await _unitOfWork.Employee.Update(EmployeeVM.Employee);
                return RedirectToPage("./Index");

            }

        }
    }
}
