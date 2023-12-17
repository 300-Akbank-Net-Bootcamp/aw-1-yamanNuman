using FluentValidation;
using VbApi.Controllers;

namespace VbApi.Validator;

public class AppEmployeeValidator : AbstractValidator<Employee>
{
    private bool AgeValidate(DateTime value)
    {
        DateTime now = DateTime.Today;
        int age = now.Year - Convert.ToDateTime(value).Year;
        if (age < 18)
        {
            return false;
        }

        return true;
    }

    private bool TitleValidate(string title)
    {
        if (title.Equals("Senior") || title.Equals("Mid"))
        {
            return true;
        }

        return false;
    }
    
    public AppEmployeeValidator()
    {
        RuleFor(f => f.Name)
            .NotEmpty()
            .WithMessage("Isim alani bos birakilamaz.")
            .MinimumLength(10)
            .WithMessage("10 karakterden asagi olamaz.")
            .MaximumLength(30)
            .WithMessage("30 karakterden buyuk olamaz.");

        RuleFor(f => f.Email)
            .NotEmpty()
            .WithMessage("E-mail alani bos birakilamaz")
            .EmailAddress()
            .WithMessage("Gecerli formatta e-mail adresi giriniz");
        
        RuleFor(f => f.Phone)
            .NotEmpty()
            .WithMessage("Telefon numarasi bos birakilamaz.")
            .Matches(@"^(05(\d{9}))$")
            .WithMessage("Lutfen numaranizi 05xxxxxxxxx formatinda giriniz.");

        RuleFor(f =>f.HourlySalary)
            .NotEmpty()
            .WithMessage("Saatlik ucreti bos birakmayiniz.")
            .InclusiveBetween(50, 400)
            .WithMessage("Saatlik ucret 50-400 arasi olmalidir.");
        
        RuleFor(f => f.DateOfBirth)
            .NotEmpty()
            .WithMessage("Dogum tarihi bos birakilamaz.")
            .Must(AgeValidate)
            .WithMessage("18 Yasindan kucuk olamaz.");

        RuleFor(f => f.Title)
            .NotEmpty()
            .WithMessage("Title alani bos gecilemez.")
            .Must(TitleValidate)
            .WithMessage("Title Senior veya Mid olmalidir.");
    }
}