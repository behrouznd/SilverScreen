namespace Entities.Exceptions
{
    public sealed class MovieCollectionBadRequest : BadRequestException
    {
        public MovieCollectionBadRequest() : base("Movie collection  sent from client is null")
        {

        }
    }
}
