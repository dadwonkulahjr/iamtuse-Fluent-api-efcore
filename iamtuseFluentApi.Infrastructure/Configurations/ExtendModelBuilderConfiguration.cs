using iamtuseFluentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace iamtuseFluentApi.Infrastructure.Configurations
{
    public static class ExtendModelBuilderConfiguration
    {
        public static ModelBuilder SeedDatabaseWithInitialData(this ModelBuilder modelBuilder)
        {
            //Do work here!
            modelBuilder.Entity(typeof(Employee))
                        .HasData(GetEmployeeList());
            modelBuilder.Entity<Gender>()
                        .HasData(GetGenderList());
            return modelBuilder;
        }

        private static IEnumerable<Employee> GetEmployeeList()
        {
            return new List<Employee>()
            {
                new()
                {
                    EmployeeId = 1,
                    FirstName = "iamtuse",
                    LastName = "theProgrammer",
                    Email = "iamtuse@iamtuse.com",
                    Salary = 4500000,
                    GenderId = 1
                },
                new()
                {
                    EmployeeId = 2,
                    FirstName = "Tom",
                    LastName = "Smith",
                    Email = "tom@iamtuse.com",
                    Salary = 5000000,
                    GenderId = 1
                },
                new()
                {
                    EmployeeId = 3,
                    FirstName = "Sara",
                    LastName = "Peters",
                    Email = "sara@iamtuse.com",
                    Salary = 250000,
                    GenderId = 2
                },
                new()
                {
                    EmployeeId = 4,
                    FirstName = "Mary",
                    LastName = "Goslins",
                    Email = "mary@iamtuse.com",
                    Salary = 100000,
                    GenderId = 2
                },
                new()
                {
                    EmployeeId = 5,
                    FirstName = "Test",
                    LastName = "Data",
                    Email = "test@iamtuse.com",
                    Salary = 100000,
                    GenderId = 3
                }
            };
        }
        private static IEnumerable<Gender> GetGenderList()
        {
            return new List<Gender>()
            {
                new()
                {
                    GenderId = 1,
                    Name = "Male",

                },
                new()
                {
                    GenderId = 2,
                    Name = "Female",
                },
                new()
                {
                    GenderId = 3,
                    Name = "Unknown",
                },
            };
        }
    }
}
