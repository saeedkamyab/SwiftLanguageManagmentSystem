namespace SLMS.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
        : base($"{name} width id {key} was not found.")
        {
            
        }
        public NotFoundException()
        {
            
        }
    }
}
