using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Bookings")]
public class Booking : BaseEntity
{
    public int Price { get; set; }
    
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    
    [ForeignKey("PaymentMethodId")]
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
}