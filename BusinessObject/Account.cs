using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Accounts")]
public class Account : BaseEntity
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public string CardNumber { get; set; }
    public string Bank { get; set; }
    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    
}