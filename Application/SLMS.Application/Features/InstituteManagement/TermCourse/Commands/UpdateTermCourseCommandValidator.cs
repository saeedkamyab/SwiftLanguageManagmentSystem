using FluentValidation;
using SLMS.Application.Features.InstituteManagement.TermCourse.Commands;

namespace SLMS.Application.Features.InstituteManagement.TermCourse
{
    public class UpdateTermCourseCommandValidator : AbstractValidator<UpdateTermCourseCommand>
    {
        public UpdateTermCourseCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");
        }
    }
}
