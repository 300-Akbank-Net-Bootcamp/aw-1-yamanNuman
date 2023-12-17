using System.Data;
using FluentValidation;
using VbApi.Controllers;

namespace VbApi.Validator;

public class AppStaffValidator : AbstractValidator<Staff>
{
    public AppStaffValidator()
    {
        RuleFor(f => f.Name)
            .NotEmpty()
            .WithMessage("Isim alanini bos birakmayiniz.")
            .MinimumLength(10)
            .WithMessage("Isim alani 10 karakterden dusuk olmamalidir.")
            .MaximumLength(30)
            .WithMessage("Isim alani 30 karakterden fazla olmamalidir.");
        
        RuleFor(f => f.Email)
            .NotEmpty()
            .WithMessage("E-mail alani bos gecilemez.")
            .EmailAddress()
            .WithMessage("Gecerli bir E-mail adresi giriniz.");

        //TR Phone => 05xx-xxx-xx-xx format
        RuleFor(f => f.Phone)
            .NotEmpty()
            .WithMessage("Telefon numarasi bos birakilamaz.")
            .Matches(@"^(05(\d{9}))$")
            .WithMessage("Lutfen numaranizi 05987654321 formatinda giriniz.");

        RuleFor(f => f.HourlySalary)
            .NotEmpty()
            .WithMessage("Saatlik ucreti bos birakmayiniz.")
            .InclusiveBetween(30, 400)
            .WithMessage("Saatlik ucret 30-400 arasi olmalidir.");
    }
}