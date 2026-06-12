using FluentValidation;
using SLMS.Application.Features.SocialNetwork.Comments.Commands;

namespace SLMS.Application.Features.SocialNetwork.Commands
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(item => item.CommentContext)
                .NotEmpty().WithMessage("متن کامنت اجباری است.")
                .MaximumLength(250).WithMessage("متن کامنت نمیتواند بیش از 350 کاراکتر باشد");
        }
    }
}
