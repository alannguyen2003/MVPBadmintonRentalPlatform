using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Bookings")]
public class Booking : BaseEntity
{
    public int Price { get; set; }
    
    [ForeignKey("BadmintonCourtId")]
    public int BadmintonCourtId { get; set; }
    public virtual BadmintonCourt BadmintonCourt { get; set; }
    
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    
    [ForeignKey("BookingStatusId")]
    public int BookingStatusId { get; set; }
    public virtual BookingStatus BookingStatus { get; set; }
}