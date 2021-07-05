using iamtuseFluentApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Application.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> GetDropdownListForGender { get; set; }
        public IEnumerable<Employee> EmployeeList { get; set; }
        public Gender Gender { get; set; } = new();

    }
}
