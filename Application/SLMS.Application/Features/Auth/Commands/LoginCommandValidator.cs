using FluentValidation;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Auth.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(item => item.UserNameOrEmail)
                .NotEmpty().WithMessage("برای ورود لطفا نام کاربری یا ایمیل را وارد نمایید")
                .MaximumLength(250).WithMessage("نام کاربری یا ایمیل نمیتواند بیش از 250 کاراکتر باشد");
           
            RuleFor(item => item.Password)
             .NotEmpty().WithMessage("گذرواژه وارد کنید")
             .MinimumLength(8).WithMessage("گذرواژه نمیتواند کمتر از 8 کاراکتر باشد")
             .MaximumLength(1500).WithMessage("گذرواژه نمیتواند بیش از 1500 کاراکتر باشد"); 
        }
    }
}
