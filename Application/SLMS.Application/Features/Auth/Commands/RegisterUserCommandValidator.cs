using FluentValidation;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Auth.Commands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(item => item.UserName)
                .NotEmpty().WithMessage("نام کاربری اجباری میباشد")
                .NotNull().WithMessage("نام کاربری اجباری میباشد")
                .MaximumLength(250).WithMessage("نام کاربری نمیتواند بیش از 250 کاراکتر باشد");
           
            RuleFor(item => item.Password)
             .NotEmpty().WithMessage("گذرواژه اجباری میباشد")
             .NotNull().WithMessage("گذرواژه اجباری میباشد")
             .MinimumLength(8).WithMessage("گذرواژه نمیتواند کمتر از 8 کاراکتر باشد")
             .MaximumLength(1500).WithMessage("گذرواژه نمیتواند بیش از 1500 کاراکتر باشد");


            RuleFor(item => item.Email)
               .NotEmpty().WithMessage("ایمیل اجباری میباشد")
               .NotNull().WithMessage("ایمیل اجباری میباشد")
               .EmailAddress().WithMessage("ایمیل وارد شده معتبر نیست")
               .MaximumLength(250).WithMessage("ایمیل نمیتواند بیش از 250 کاراکتر باشد");
        }
    }
}
