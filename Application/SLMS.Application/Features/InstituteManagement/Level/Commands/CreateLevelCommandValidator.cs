using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class CreateLevelCommandValidator : AbstractValidator<CreateLevelCommand>
    {
        public CreateLevelCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");


        }
    }
}
