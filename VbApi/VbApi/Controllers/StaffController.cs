using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using VbApi.Validator;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace VbApi.Controllers;

public class Staff
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public decimal HourlySalary { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    public StaffController()
    {
    }

    [HttpPost]
    public Staff Post([FromBody] Staff value)
    {
        AppStaffValidator validator = new AppStaffValidator();
        ValidationResult result = validator.Validate(value);
        if (!result.IsValid)
        {
            foreach (var failure in result.Errors)
            {
               // Console.WriteLine(failure.PropertyName + failure.ErrorMessage);
            }
        }

        return value;
    }
}