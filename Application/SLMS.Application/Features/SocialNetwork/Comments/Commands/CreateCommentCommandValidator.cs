using FluentValidation;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;

namespace SLMS.Application.Features.SocialNetwork.Commands
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(item => item.CommentContext)
                .NotEmpty().WithMessage("متن کامنت اجباری است.")
                .MaximumLength(250).WithMessage("متن کامنت نمیتواند بیش از 350 کاراکتر باشد");
           
            RuleFor(item => item.PostId)
             .NotEmpty().WithMessage("شناسه پست نمیتواند خالی باشد"); 
           
            RuleFor(item => item.UserId)
             .NotEmpty().WithMessage("شناسه کاربری نمیتواند خالی باشد"); 
        }
    }
}
