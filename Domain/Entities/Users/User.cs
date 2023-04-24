using Microsoft.AspNetCore.Identity;

namespace Entities.Users
{
    public class User : IdentityUser
    {
        public int UserLevel { get; set; }
        public DateTime LevelStartedDate { get; set; }
        public DateTime LevelEndedDate { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
