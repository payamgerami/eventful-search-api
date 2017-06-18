using Eventful.Contract.V1.Requests;
using FluentValidation;

namespace Eventful.Contract.V1.Validators
{
    public class SearchEventsRequestValidator : AbstractValidator<SearchEventsRequest>
    {
        public SearchEventsRequestValidator()
        {
            RuleFor(req => req.Address)
                .NotEmpty();

            RuleFor(req => req.Radius)
                .GreaterThan(0)
                .LessThan(300);

            RuleFor(req => req.DateStart)
                .NotEmpty()
                .LessThan(e => e.DateEnd)
                .Must((e, d) => (e.DateEnd.Subtract(e.DateStart)).TotalDays <= 28)
                .WithMessage("Maximum rage is 28 days");

            RuleFor(req => req.DateEnd)
                .NotEmpty()
                .GreaterThan(e => e.DateStart)
                .Must((e, d) => (e.DateEnd.Subtract(e.DateStart)).TotalDays <= 28)
                .WithMessage("Maximum rage is 28 days");
        }
    }
}