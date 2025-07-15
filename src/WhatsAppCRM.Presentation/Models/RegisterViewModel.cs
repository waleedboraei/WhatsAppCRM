using System.ComponentModel.DataAnnotations;

namespace WhatsAppCRM.Presentation.Models
{
    public class RegisterViewModel
    {
        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
        [Required][DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
        [Required][DataType(DataType.Password)][Compare("Password")] public string ConfirmPassword { get; set; } = string.Empty;
    }
}