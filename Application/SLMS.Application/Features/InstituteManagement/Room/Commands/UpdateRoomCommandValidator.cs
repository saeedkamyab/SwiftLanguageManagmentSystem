using FluentValidation;
using SLMS.Application.Features.InstituteManagement.Room.Commands;

namespace SLMS.Application.Features.InstituteManagement.Room
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان سطح نمیتواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان سطح نمیتواند بیش از 100 کاراکتر باشد");
        }
    }
}
