using Api_D01.Models;
using Api_D01.Service;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_D01_D02.Validators
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            ApiDbContext db = (ApiDbContext)validationContext.GetService(typeof(ApiDbContext));

            if (value == null)
            {
                return new ValidationResult("Department name must be Enter");
            }
            string departmentName = value.ToString();
            int currentDepartmentId = (int)validationContext.ObjectInstance.GetType().GetProperty("id").GetValue(validationContext.ObjectInstance, null);

            var existingDepartment = db.Departments
                .FirstOrDefault(d => d.name == departmentName && d.id != currentDepartmentId);

            if (existingDepartment == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Department name must be unique.");
            }

        }




        

    }
}
