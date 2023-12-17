using System.ComponentModel.DataAnnotations;
using VbApi.Controllers;

namespace VbApi.Validator;

public class CustomValidationAttribute : ValidationAttribute
{
    public CustomValidationAttribute(double minMidSalary, double minSeniorSalary)
    {
        MinMidSalary = minMidSalary;
        MinSeniorSalary = minSeniorSalary;
    }
    private double MinMidSalary { get; }
    private double MinSeniorSalary { get; }
    private string GetErrorMessage() => $"Minimum hourly salary is not valid.";

    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
         var employee = (Employee)validationContext.ObjectInstance;
         var hourlySalary = (double)value;
        var isValidSalary = employee.Title == "Senior"
            ? hourlySalary > 200 & hourlySalary < 400
            : hourlySalary > 50 & hourlySalary < 200;

        return isValidSalary ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
    }
}