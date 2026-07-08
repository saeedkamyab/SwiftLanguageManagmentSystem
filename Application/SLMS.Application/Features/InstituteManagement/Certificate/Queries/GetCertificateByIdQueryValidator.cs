using FluentValidation;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificateByIdQueryValidator : AbstractValidator<GetCertificateByIdQuery>
    {
        public GetCertificateByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Certificate id is required.");
        }
    }
}
