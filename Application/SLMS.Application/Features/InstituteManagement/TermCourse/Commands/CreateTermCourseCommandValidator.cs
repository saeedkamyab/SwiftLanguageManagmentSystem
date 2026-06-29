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

            RuleFor(st => st.StartTime)
                .LessThan(et => et.EndTime)
                .WithMessage("زمان شروع باید قبل از زمان پایان باشد.");

            RuleFor(et => et.EndTime)
           .GreaterThan(st => st.StartTime)
           .WithMessage("زمان پایان باید بعد از زمان شروع باشد.");

         
            RuleFor(sd => sd.StartDate)
                   .LessThan(ed => ed.EndDate)
                   .WithMessage("تاریخ شروع باید قبل از تاریخ پایان باشد.");

            RuleFor(ed => ed.EndDate)
           .GreaterThan(sd => sd.StartDate)
           .WithMessage("تاریخ پایان باید بعد از تاریخ شروع باشد.");

            RuleFor(x => x.LevelId)
          .NotEmpty().WithMessage("سطح دوره باید مشخص باشد.");


            RuleFor(x => x.InstituteId)
          .NotEmpty().WithMessage("آموزشگاه دوره باید مشخص باشد.");
         
            
            RuleFor(x => x.RoomId)
          .NotEmpty().WithMessage("اتاق دوره باید مشخص باشد.");
            
            
            RuleFor(x => x.TeacherId)
          .NotEmpty().WithMessage("معلم دوره باید مشخص باشد.");
          
            
            RuleFor(x => x.WeekDays.Count)
          .GreaterThan(0).WithMessage("روزهای دوره باید مشخص باشد.");



        }
    }
}
