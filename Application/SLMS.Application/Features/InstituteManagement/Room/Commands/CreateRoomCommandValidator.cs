using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Room.Commands
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");
        }
    }
}
