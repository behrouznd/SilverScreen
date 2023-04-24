using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Users
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage ="User Name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
