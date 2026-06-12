using FluentValidation;

namespace SLMS.Application.Features.SocialNetwork.Posts.Queries
{
    public class GetPostListQueryValidator : AbstractValidator<GetPostListQuery>
    {
        public GetPostListQueryValidator()
        {
            RuleFor(item => item.PageSize)
               .InclusiveBetween(1,100)
               .WithMessage("تعداد در صفحه باید عددی بین 1 تا 100 باشد");
        }
    }
}
