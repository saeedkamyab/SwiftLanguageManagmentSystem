using SLMS.Shared.Enums;

namespace SLMS.Application.Contracts.Identity
{
    public interface IAuthorizedRequest
    {
        Guid InstituteId { get; }
    }
}
