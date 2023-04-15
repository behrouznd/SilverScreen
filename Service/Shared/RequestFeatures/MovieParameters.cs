namespace Shared.RequestFeatures
{
    public class MovieParameters : RequestParameters
    {
        public MovieParameters()
        {
            OrderBy = "Title";
        }
        public string? SearchTitle { get; set; }

        public int PublicationYear { get; set; }
    }
}
