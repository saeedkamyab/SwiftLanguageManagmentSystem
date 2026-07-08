using FluentValidation;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Queries
{
    public class GetCertificatesQueryValidator : AbstractValidator<GetCertificatesQuery>
    {
        public GetCertificatesQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("PageNumber must be greater than zero.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100.");

            RuleFor(x => x.ClassificationId)
                .NotEqual(Guid.Empty).When(x => x.ClassificationId.HasValue)
                .WithMessage("ClassificationId is not valid.");

            RuleFor(x => x.Status)
                .Must(x => x is null || x != CertificateStatus.None)
                .WithMessage("Certificate status is not valid.");
        }
    }
}
