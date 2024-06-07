using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Roles")]
public class Role : BaseEntity
{
    public string RoleName { get; set; }
}