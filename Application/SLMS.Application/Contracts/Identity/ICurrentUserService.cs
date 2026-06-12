namespace SLMS.Application.Contracts.Identity
{
    public interface ICurrentUserService
    {
       Guid? Id { get; }
        string UserName {  get; }
    }
}
