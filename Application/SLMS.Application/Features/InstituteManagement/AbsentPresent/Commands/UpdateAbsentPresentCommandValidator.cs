using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class UpdateAbsentPresentCommandValidator : AbstractValidator<UpdateAbsentPresentCommand>
    {
        public UpdateAbsentPresentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("AbsentPresent id is required.");

            RuleFor(x => x.ClassifictionId)
                .NotEmpty().WithMessage("ClassifictionId is required.");

            RuleFor(x => x.InstituteId)
                .NotEmpty().WithMessage("InstituteId is required.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.SessionNumber)
                .GreaterThan(0).WithMessage("SessionNumber must be greater than zero.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Description cannot be more than 250 characters.");
        }
    }
}
