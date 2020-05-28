using FluentValidation;
using System.Net.Http;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Commands.Validators
{
    public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
    { 
        private const string BaseUrl = "https://restcountries.eu/rest/v2/name/";
        public CreateApplicantCommandValidator()
        {
            HttpClient client = new HttpClient();
            RuleFor(v => v.Name).MinimumLength(5);
            RuleFor(v => v.FamilyName).MinimumLength(5);
            RuleFor(v => v.Address).MinimumLength(10);

            RuleFor(v => v.EmailAddress).EmailAddress();
            RuleFor(v => v.Age).InclusiveBetween(from: 20, to: 60);
            RuleFor(v => v.Hired).NotNull();
            
        }
    }
}
