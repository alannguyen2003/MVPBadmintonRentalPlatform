using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("BookingSlot")]
public class BookingSlot : BaseEntity
{
    [ForeignKey("BookingId")]
    public int BookingId { get; set; }
    public virtual Booking Booking { get; set; }
    
    [ForeignKey("SlotId")]
    public int SlotId { get; set; }
    public virtual Slot Slot { get; set; }
}