namespace Entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid guidCategory) : base($"The Category with id :{guidCategory} doesn't exist in the database" )
        {
        }
    }
}
