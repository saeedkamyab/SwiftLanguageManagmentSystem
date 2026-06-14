using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class CreateInstituteCommandValidator:AbstractValidator<CreateInstituteCommand>
    {
        public CreateInstituteCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان آموزشگاه نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان آموزشگاه نمیتواند بیش از 100 کاراکتر باشد");

            RuleFor(x => x.Fields)
               .NotEmpty().WithMessage("رشته های آموزشگاه نمیتواند خالی باشد.")
               .MaximumLength(300).WithMessage("رشته های آموزشگاه نمیتواند بیش از 300 کاراکتر باشد");

            RuleFor(x => x.Description)
              .MaximumLength(300).WithMessage("توضیحات آموزشگاه نمیتواند بیش از 300 کاراکتر باشد");
        }
    }
}
