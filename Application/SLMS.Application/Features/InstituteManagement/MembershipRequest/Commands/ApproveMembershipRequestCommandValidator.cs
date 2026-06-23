using FluentValidation;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class ApproveMembershipRequestCommandValidator : AbstractValidator<ApproveMembershipRequestCommand>
    {
        public ApproveMembershipRequestCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه درخواست نمیتواند خالی باشد.") ;

            RuleFor(x => x.MemberType)
    .NotEqual(MemberType.Founder).WithMessage("نمیتوان موسس به سیستم اضافه کرد.") ;
        }
    }
}
