using System.ComponentModel.DataAnnotations;

namespace DataTransfer.Request;

public class PlayerRegisterRequest
{
    public string FullName { get; set; }
    [EmailAddress(ErrorMessage = "Your email address are wrong types.")]
    public string Email { get; set; }
    [StringLength(32, ErrorMessage = "Your password must smaller than 32 characters.")]
    public string Password { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
}