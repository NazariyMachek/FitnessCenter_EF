using FitnessCenter_EF.BLL.DTOs.Subscription;
using FluentValidation;

namespace FitnessCenter_EF.API.Validation.Subscription
{
    public class SubscriptionDTO_Validator : AbstractValidator<SubscriptionDTO>
    {
        public SubscriptionDTO_Validator()
        {
            RuleFor(entity => entity.SubscriptionId)
                    .NotEmpty().WithMessage("Id is required");
            RuleFor(entity => entity.CustomerName)
                    .NotEmpty().WithMessage("CustomerName is required");
            RuleFor(entity => entity.CustomerPhone)
                    .NotEmpty().WithMessage("CustomerPhone is required");
            RuleFor(entity => entity.StartDate)
                    .NotEmpty().WithMessage("StartDate is required");
            RuleFor(entity => entity.EndDate)
                    .NotEmpty().WithMessage("EndDate is required");
            RuleFor(entity => entity.Price > 0)
                    .NotEmpty().WithMessage("The price cannot be less than 0");
        }
    }
}
