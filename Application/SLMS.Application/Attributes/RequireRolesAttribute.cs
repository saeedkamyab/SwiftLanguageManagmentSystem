using SLMS.Shared.Enums;

namespace SLMS.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequireRolesAttribute:Attribute
    {
        public MemberType[] MemberTypes { get; }
        public RequireRolesAttribute(params MemberType[] memberTypes)
        {
            MemberTypes = memberTypes;
        }
    }
}
