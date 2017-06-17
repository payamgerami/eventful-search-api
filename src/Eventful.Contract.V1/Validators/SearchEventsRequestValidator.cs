using Eventful.Contract.V1.Requests;
using FluentValidation;

namespace Eventful.Contract.V1.Validators
{
    public class SearchEventsRequestValidator : AbstractValidator<SearchEventsRequest>
    {
        public SearchEventsRequestValidator()
        {
            RuleFor(req => req.Address).NotEmpty().WithMessage("Please specify an address");
            RuleFor(req => req.Radius).NotEmpty().WithMessage("Please specify the radius");
            RuleFor(req => req.DateStart).NotEmpty().WithMessage("Please specify the start date");
            RuleFor(req => req.DateEnd).NotEmpty().WithMessage("Please specify the end date");
            RuleFor(req => req.Category).NotEmpty().WithMessage("Please specify a category");
        }
    }
}