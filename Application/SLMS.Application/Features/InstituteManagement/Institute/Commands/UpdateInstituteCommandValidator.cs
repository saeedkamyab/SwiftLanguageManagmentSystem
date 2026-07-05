using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class UpdateInstituteCommandValidator:AbstractValidator<UpdateInstituteCommand>
    {
        public UpdateInstituteCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان آموزشگاه نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان آموزشگاه نمیتواند بیش از 100 کاراکتر باشد");



            RuleFor(x => x.Description)
              .MaximumLength(300).WithMessage("توضیحات آموزشگاه نمیتواند بیش از 300 کاراکتر باشد");
        }
    }
}
