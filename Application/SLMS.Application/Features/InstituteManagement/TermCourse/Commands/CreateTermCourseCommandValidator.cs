using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class CreateTermCourseCommandValidator : AbstractValidator<CreateTermCourseCommand>
    {
        public CreateTermCourseCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");
        }
    }
}
