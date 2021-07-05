using System.ComponentModel.DataAnnotations;

namespace iamtuseFluentApi.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name ="Wage")]
        [Required]
        public decimal Salary { get; set; }
        [Display(Name = "Office Email"), Required]
        public string Email { get; set; }
        [Display(Name ="Gender")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
