namespace Shared.RequestFeatures
{
    public class MovieParameters : RequestParameters
    {
        public string? SearchTitle { get; set; }

        public int PublicationYear { get; set; }
    }
}
