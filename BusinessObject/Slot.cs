using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Slots")]
public class Slot : BaseEntity
{
    public int HourStart { get; set; }
    public int MinuteStart { get; set; }
    public int HourEnd { get; set; }
    public int MinuteEnd { get; set; }
    public int CourtId { get; set; }
    public virtual Court Court { get; set; }
}