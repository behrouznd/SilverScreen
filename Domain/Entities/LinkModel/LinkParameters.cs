using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModel
{
    public record LinkParameters(MovieParameters movieParameters, HttpContext Context);
}
