using FitnessCenter_EF.BLL.DTOs.Instructor;
using FluentValidation;

namespace FitnessCenter_EF.API.Validation.Instructor
{
    public class InstructorDTO_Validator : AbstractValidator<InstructorDTO>
    {
        public InstructorDTO_Validator()
        {
            RuleFor(entity => entity.InstructorId)
                    .NotEmpty().WithMessage("InstructorId is required");
            RuleFor(entity => entity.Name)
                    .NotEmpty().WithMessage("Name is required");
            RuleFor(entity => entity.Phone)
                    .NotEmpty().WithMessage("Phone is required");
            RuleFor(entity => entity.Specialization)
                    .NotEmpty().WithMessage("Specialization is required");
        }
    }
}
