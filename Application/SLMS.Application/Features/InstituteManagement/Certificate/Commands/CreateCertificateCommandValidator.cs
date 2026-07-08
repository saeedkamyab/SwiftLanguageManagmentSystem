using FluentValidation;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
    {
        public CreateCertificateCommandValidator()
        {
            RuleFor(x => x.ClassificationId)
                .NotEmpty().WithMessage("ClassificationId is required.");

            RuleFor(x => x.InstituteId)
                .NotEmpty().WithMessage("InstituteId is required.");

            RuleFor(x => x.Status)
                .Must(x => x != CertificateStatus.None).WithMessage("Certificate status is required.");

            RuleFor(x => x.Reading).InclusiveBetween(0, 100).WithMessage("Reading must be between 0 and 100.");
            RuleFor(x => x.Writting).InclusiveBetween(0, 100).WithMessage("Writting must be between 0 and 100.");
            RuleFor(x => x.Listening).InclusiveBetween(0, 100).WithMessage("Listening must be between 0 and 100.");
            RuleFor(x => x.Speaking).InclusiveBetween(0, 100).WithMessage("Speaking must be between 0 and 100.");
            RuleFor(x => x.MidTerm).InclusiveBetween(0, 100).WithMessage("MidTerm must be between 0 and 100.");
            RuleFor(x => x.Final).InclusiveBetween(0, 100).WithMessage("Final must be between 0 and 100.");
        }
    }
}
