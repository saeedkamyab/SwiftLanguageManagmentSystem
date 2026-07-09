using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    public class DeleteAbsentPresentCommandValidator : AbstractValidator<DeleteAbsentPresentCommand>
    {
        public DeleteAbsentPresentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("AbsentPresent id is required.");

            RuleFor(x => x.InstituteId)
                .NotEmpty().WithMessage("InstituteId is required.");
        }
    }
}
