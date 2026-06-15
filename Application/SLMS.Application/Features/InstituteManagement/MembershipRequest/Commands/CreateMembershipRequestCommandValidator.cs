using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class CreateMembershipRequestCommandValidator:AbstractValidator<CreateMembershipRequestCommand>
    {
        public CreateMembershipRequestCommandValidator()
        {
            RuleFor(x => x.InstituteId)
                .NotEmpty().WithMessage("آموزشگاه انتخاب نشده است.") ;
        }
    }
}
