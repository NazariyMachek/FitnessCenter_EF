using FitnessCenter_EF.BLL.DTOs.Subscription;
using FluentValidation;

namespace FitnessCenter_EF.API.Validation.Subscription
{
    public class UpdateSubscriptionDTO_Validator : AbstractValidator<UpdateSubscriptionDTO>
    {
        public UpdateSubscriptionDTO_Validator()
        {
            RuleFor(entity => entity.SubscriptionId)
                    .NotEmpty().WithMessage("SubscriptionId is required");
            RuleFor(entity => entity.CustomerId)
                    .NotEmpty().WithMessage("CustomerId is required");
            RuleFor(entity => entity.StartDate)
                    .NotEmpty().WithMessage("StartDate is required");
            RuleFor(entity => entity.EndDate)
                    .NotEmpty().WithMessage("EndDate is required");
            RuleFor(entity => entity.Price > 0)
                    .NotEmpty().WithMessage("The price cannot be less than 0");
        }
    }
}
