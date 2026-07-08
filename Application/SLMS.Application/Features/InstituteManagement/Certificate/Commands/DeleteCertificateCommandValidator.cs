using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    public class DeleteCertificateCommandValidator : AbstractValidator<DeleteCertificateCommand>
    {
        public DeleteCertificateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Certificate id is required.");

            RuleFor(x => x.InstituteId)
                .NotEmpty().WithMessage("InstituteId is required.");
        }
    }
}
