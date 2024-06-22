using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("BookingDetail")]
public class BookingDetail : BaseEntity
{
    [ForeignKey("BookingId")]
    public int BookingId { get; set; }
    public virtual Booking Booking { get; set; }
    
    [ForeignKey("CourtId")]
    public int CourtId { get; set; }
    public virtual Court Court { get; set; }
}