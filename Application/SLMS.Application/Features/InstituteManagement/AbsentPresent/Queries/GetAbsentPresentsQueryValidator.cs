using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Queries
{
    public class GetAbsentPresentsQueryValidator : AbstractValidator<GetAbsentPresentsQuery>
    {
        public GetAbsentPresentsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("PageNumber must be greater than zero.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100.");

            RuleFor(x => x.ClassifictionId)
                .NotEqual(Guid.Empty).When(x => x.ClassifictionId.HasValue)
                .WithMessage("ClassifictionId is not valid.");
        }
    }
}
