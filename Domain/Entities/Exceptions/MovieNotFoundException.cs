namespace Entities.Exceptions
{
    public sealed class MovieNotFoundException : NotFoundException
    {
        public MovieNotFoundException(Guid id) : base($"The Movie with id : {id} doesn't exist in the database")
        {

        }
    }
}
