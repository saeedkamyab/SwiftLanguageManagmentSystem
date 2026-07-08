using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Classification.Commands
{
    public class CreateClassificationCommandValidator : AbstractValidator<CreateClassificationCommand>
    {
        public CreateClassificationCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");

            RuleFor(x => x.TermCourseId)
          .NotEmpty().WithMessage("دوره یا ترم را انتخاب کنید");


            RuleFor(x => x.PupilMembershipId)
          .NotEmpty().WithMessage("اعضای ترم یا دوره را مشخص کنید");
         
            
            RuleFor(x => x.InstituteId)
          .NotEmpty().WithMessage("آموزشگاه را انتخاب کنید");
            
        

        }
    }
}
