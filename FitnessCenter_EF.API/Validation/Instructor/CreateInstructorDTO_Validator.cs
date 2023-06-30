using FitnessCenter_EF.BLL.DTOs.Instructor;
using FluentValidation;

namespace FitnessCenter_EF.API.Validation.Instructor
{
    public class CreateInstructorDTO_Validator : AbstractValidator<CreateInstructorDTO>
    {
        public CreateInstructorDTO_Validator()
        {
            RuleFor(entity => entity.FirstName)
                    .NotEmpty().WithMessage("FirstName is required");
            RuleFor(entity => entity.LastName)
                    .NotEmpty().WithMessage("LastName is required");
            RuleFor(entity => entity.Email)
                    .NotEmpty().WithMessage("Email is required");
            RuleFor(entity => entity.Phone)
                    .NotEmpty().WithMessage("Phone is required");
            RuleFor(entity => entity.Specialization)
                    .NotEmpty().WithMessage("Specialization is required");
        }
    }
}
