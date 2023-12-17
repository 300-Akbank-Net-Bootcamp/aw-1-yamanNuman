
using Microsoft.AspNetCore.Mvc;
using VbApi.Validator;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace VbApi.Controllers;

public class Employee
{
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    [CustomValidation(minMidSalary: 50, minSeniorSalary: 200)]
    public double HourlySalary { get; set; }
    
    public string Title { get; set; }
    
}

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {
    }

    [HttpPost]
    public Employee Post([FromBody] Employee value)
    {
            AppEmployeeValidator validator = new AppEmployeeValidator();
            ValidationResult result = validator.Validate(value);
            if (!result.IsValid)
            {
            }

            return value;
    }

}