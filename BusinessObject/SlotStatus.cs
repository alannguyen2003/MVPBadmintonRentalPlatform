using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("SlotStatus")]
public class SlotStatus : BaseEntity
{
    public string Status { get; set; }

}