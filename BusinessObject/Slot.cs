using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Slots")]
public class Slot : BaseEntity
{
    public string TimeFrame { get; set; }
    public DateTime DateTime { get; set; }
    
    [ForeignKey("SlotStatusId")]
    public int SlotStatusId { get; set; }
    public virtual SlotStatus SlotStatus { get; set; }
    
    [ForeignKey("CourtId")]
    public int CourtId { get; set; }
    public virtual Court Court { get; set; }
    
    [ForeignKey("BookingDetailId")]
    public int BookingDetailId { get; set; }
    public virtual BookingDetail BookingDetail { get; set; }
}