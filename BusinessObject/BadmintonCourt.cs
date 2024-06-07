using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("BadmintonCourts")]
public class BadmintonCourt : BaseEntity
{
    public string ProfileImage { get; set; }
    public string CourtName { get; set; }
    public int NumberOfCourt { get; set; }
    public int HourStart { get; set; }
    public int MinuteStart { get; set; }
    public int HourEnd { get; set; }
    public int MinuteEnd { get; set; }
    public float PricePerHour { get; set; }
    public float PriceAtWeekend { get; set; }
    public string Address { get; set; }
    
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
}