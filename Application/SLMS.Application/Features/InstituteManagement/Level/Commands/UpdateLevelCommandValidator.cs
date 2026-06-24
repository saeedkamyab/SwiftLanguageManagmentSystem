using FluentValidation;
using SLMS.Application.Features.InstituteManagement.Level.Commands;

namespace SLMS.Application.Features.InstituteManagement.Level
{
    public class UpdateLevelCommandValidator : AbstractValidator<UpdateLevelCommand>
    {
        public UpdateLevelCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");
        }
    }
}
