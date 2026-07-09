using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentByIdQueryValidator : AbstractValidator<GetAbsentPresentByIdQuery>
    {
        public GetAbsentPresentByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("AbsentPresent id is required.");
        }
    }
}
